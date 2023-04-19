using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Constans;
using UAS.Application.Dto.Common;
using UAS.Application.Dto.Error;
using UAS.Application.Dto.Token;
using UAS.Application.Dto.User;
using UAS.Application.Features.Commands.AppUser.CreateUser;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using UAS.Application.Dto.Auth;
using System.Security.Policy;
using UAS.Application.Abstractions.Email;

namespace UAS.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.AppUser> _userManager;
        readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;
        private readonly IMailService _mailService;
        public UserService(UserManager<AppUser> userManager, IMapper mapper, IMailService mailService, Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IResult> CreateAsync(CreateUser model)
        {
            IdentityResult result = new IdentityResult();
            AppUser appUser = _mapper.Map<AppUser>(model);

            result = await _userManager.CreateAsync(appUser, model.Password);

            if (!result.Succeeded)
            {
                var errorResult = new ErrorResult();
                foreach (var error in result.Errors)
                {
                    errorResult.Message += $"{error.Code} - {error.Description}";
                }
                return errorResult;
            }

            return new SuccessResult(Message.UserCreatedIsSuccess);
        }

        public async Task<IDataResult<List<ListUser>>> GetAllUserAsync(bool includeDeleted = false)
        {
            var users = await _userManager.Users.Where(x => includeDeleted ? true : x.PersonelSMI == false).ToListAsync();
            var result = users.Select(user => new ListUser
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
            }).ToList();

            return new SuccessDataResult<List<ListUser>>(result);
        }

        public async Task<IDataResult<List<ListUser>>> GetDeletedUsersAsync()
        {
            var deletedUsers = await _userManager.Users.Where(x => x.PersonelSMI == true).ToListAsync();
            var result = deletedUsers.Select(user => new ListUser
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
            }).ToList();
            return new SuccessDataResult<List<ListUser>>(result);
        }

        public async Task<IDataResult<AppUser>> GetByRefreshTokenAsync(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
            if (user == null) return new ErrorDataResult<AppUser>(Message.UserNotFound);

            return new SuccessDataResult<AppUser>(user);
        }

        public async Task<IResult> UpdateRefreshTokenAsync(RefreshToken refreshToken, AppUser user)
        {
            user.RefreshToken = refreshToken.Token;
            user.RefreshTokenEndDate = refreshToken.ExpirationTime;

            var result = await _userManager.UpdateAsync(user);

            return new SuccessResult();
        }

        public async Task<GetUserResponse> GetById(int id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<AppUser, GetUserResponse>(appUser);
        }
        public async Task<IResult> DeleteById(DeleteUser deleteUser)
        {
            AppUser appUser = await _userManager.FindByIdAsync(deleteUser.Id.ToString());
            appUser.PersonelSMI = true;
            var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded)
                return new SuccessResult();
            else
                return new ErrorResult();
        }
        public async Task<IResult> DeleteByIdPermanent(DeleteUser deleteUser)
        {
            AppUser appUser = await _userManager.FindByIdAsync(deleteUser.Id.ToString());
            var result = await _userManager.DeleteAsync(appUser);
            if (result.Succeeded)
                return new SuccessResult();
            else
                return new ErrorResult();
        }
        public async Task<IResult> RestoreUserAsync(RestoreUser restoreUser)
        {
            AppUser appUser = await _userManager.FindByIdAsync(restoreUser.Id.ToString());
            appUser.PersonelSMI = false;
            var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded)
                return new SuccessResult();
            else
                return new ErrorResult();
        }
        public async Task<IResult> UpdateUserAsync(UpdateUser user)
        {
            AppUser appUser = await _userManager.FindByIdAsync(user.Id.ToString());            
            appUser.Name = user.Name;
            appUser.Surname = user.Surname;
            appUser.Email = user.Email;
            appUser.UserName = user.Username;            
            if (user.IsCheckedNewPassword && !string.IsNullOrEmpty(user.NewPassword))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                var passChangeResult = await _userManager.ResetPasswordAsync(appUser, token, user.NewPassword);
                if (!passChangeResult.Succeeded)
                {
                    var errorResult = new ErrorResult();
                    foreach (var error in passChangeResult.Errors)
                    {
                        errorResult.Message += $"{error.Code} - {error.Description}";
                    }
                    return errorResult;
                }
            }
            var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded)
                return new SuccessResult();
            else
                return new ErrorResult();
        }
        public async Task<IResult> UpdateUserFormMyProfileAsync(UpdateUserMyProfile user)
        {
            AppUser appUser = await _userManager.FindByIdAsync(user.Id.ToString());
            appUser.Name = user.Name;
            appUser.Surname = user.Surname;
            appUser.Email = user.Email;
            appUser.PersonelImageUrl = user.PersonelImageUrl;
            appUser.PhoneNumber = user.PhoneNumber;
            appUser.Address = user.Address;
            appUser.TcKimlikNo = user.TcKimlikNo;
            appUser.PersonelDogumYili = user.PersonelDogumYili;
            
            
            var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded)
                return new SuccessResult();
            else
                return new ErrorResult();
        }
        public async Task<GetUserResponse> GetByUserName(GetUser getUser)
        {
            return _mapper.Map<AppUser, GetUserResponse>(await _userManager.FindByNameAsync(getUser.UserName));
        }

        public async Task<PasswordResetResponse> ResetPasswordSendEmailLink(PasswordReset passwordReset)
        {
            var user = await _userManager.FindByEmailAsync(passwordReset.Email);
            if (user == null) return new PasswordResetResponse { IsSuccess = false, Message = "Sistemde böyle bir email bulunamadı" };
            var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = $"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}{_httpContextAccessor.HttpContext?.Request.PathBase}/Auth/ResetPasswordConfirm?userId={user.Id}&token={resetPasswordToken}";
            var isSuccessEmailSend = _mailService.ResetPasswordConfirmedEmail(url, user.Email);
            return new PasswordResetResponse { IsSuccess = isSuccessEmailSend, Message = isSuccessEmailSend ? "e-mail adresinizi kontrol ediniz" : "beklenmedik bir hata oluştu daha sonra tekrar deneyiniz." };
        }

        public async Task<PasswordResetConfirmResponse> ResetPasswordConfirm(PasswordResetConfirm passwordResetConfirm)
        {
            var user = await _userManager.FindByIdAsync(passwordResetConfirm.UserId);
            if (passwordResetConfirm.NewPassword != passwordResetConfirm.NewPasswordConfirm)
                return new PasswordResetConfirmResponse { IsSuccess = false, Message = "Şifreler birbirleriyle uyuşmuyor" };
            var response = await _userManager.ResetPasswordAsync(user, passwordResetConfirm.Token, passwordResetConfirm.NewPassword);
            return response.Succeeded ? new PasswordResetConfirmResponse { IsSuccess = true, Message = "Şifre Başarıyla güncellendi" } : new PasswordResetConfirmResponse { IsSuccess = false, Message = "beklenmedik bir hata oluştu" };
        }
    }
}

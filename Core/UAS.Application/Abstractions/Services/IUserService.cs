using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.Auth;
using UAS.Application.Dto.Common;
using UAS.Application.Dto.Error;
using UAS.Application.Dto.Token;
using UAS.Application.Dto.User;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;

namespace UAS.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<IResult> CreateAsync(CreateUser model);
        Task<IDataResult<List<ListUser>>> GetAllUserAsync(bool includeDeleted = false);
        Task<IDataResult<List<ListUser>>> GetDeletedUsersAsync();
        Task<IDataResult<AppUser>> GetByRefreshTokenAsync(string refreshToken);
        Task<IResult> DeleteById(DeleteUser deleteUser);
        Task<IResult> DeleteByIdPermanent(DeleteUser deleteUser);
        Task<IResult> UpdateRefreshTokenAsync(RefreshToken refreshToken, AppUser user);
        Task<IResult> UpdateUserAsync(UpdateUser user);
        Task<IResult> UpdateUserFormMyProfileAsync(UpdateUserMyProfile user);
        Task<IResult> RestoreUserAsync(RestoreUser user);
        Task<GetUserResponse> GetByUserName(GetUser getUser);
        Task<GetUserResponse> GetById(int id);
        Task<PasswordResetResponse> ResetPasswordSendEmailLink(PasswordReset passwordReset);
        Task<PasswordResetConfirmResponse> ResetPasswordConfirm(PasswordResetConfirm passwordResetConfirm);
    }


}

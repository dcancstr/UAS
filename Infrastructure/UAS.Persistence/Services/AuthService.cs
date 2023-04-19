using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

using UAS.Application.Abstractions.Services;
using UAS.Application.Abstractions.Token;
using UAS.Application.Constans;
using UAS.Application.Dto.Auth;
using UAS.Application.Dto.Token;
using UAS.Application.Exceptions;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;
using UAS.Persistence.Extensions;

namespace UAS.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly IUserService _userService;
        readonly ITokenService _tokenService;
        readonly SignInManager<AppUser> _signInManager;
        readonly UserManager<AppUser> _userManager;

        public AuthService(IUserService userService,
                           SignInManager<AppUser> signInManager,
                           ITokenService tokenService,
                           UserManager<AppUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<IDataResult<AccessToken>> LoginAsync(LoginUser loginUser)
        {
            var user = await _signInManager.LoginAsync(loginUser);
            if (user == null) return new ErrorDataResult<AccessToken>(Message.UserNameOrEmailAndPasswordFailed);

            await _signInManager.SignInAsync(user, true);
            var token = _tokenService.CreateAccessToken(user);
            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user);

            return new SuccessDataResult<AccessToken>(token, Message.LoginSuccess);
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IDataResult<AccessToken>> RefreshTokenLoginAsync(string refreshToken)
        {
            var userResult = await _userService.GetByRefreshTokenAsync(refreshToken);
            if (userResult.Data == null ||
                userResult.Data.RefreshTokenEndDate < DateTime.UtcNow) return new ErrorDataResult<AccessToken>(Message.LoginFailed);

            var token = _tokenService.CreateAccessToken(userResult.Data);
            await _userService.UpdateRefreshTokenAsync(token.RefreshToken, userResult.Data);
            if (userResult.Success)
            {
                await _signInManager.SignOutAsync();
                await _signInManager.SignInAsync(await _userManager.FindByNameAsync(userResult.Data.Name), true);
            }
            return new SuccessDataResult<AccessToken>(token, Message.LoginSuccess);
        }
    }
}

using Azure;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using NToastNotify;
using UAS.Application.Dto.Auth;
using UAS.Application.Dto.Token;
using UAS.Application.Features.Commands.AppUser.LoginUser;
using UAS.Application.Features.Commands.AppUser.LogOutUser;
using UAS.Application.Features.Commands.AppUser.PasswordReset;
using UAS.Application.Features.Commands.AppUser.PasswordResetConfirm;
using UAS.Domain.Entities;
using UAS.UI.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UAS.UI.Models.Configuration;

namespace UAS.UI.Controllers
{
    public class AuthController : CustomBaseController
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly UASAppSettings _uasAppSettings;

        public AuthController(IMediator mediator, IToastNotification toastNotification, IHttpContextAccessor httpContextAccessor, UASAppSettings uasAppSettings) : base(mediator, toastNotification)
        {
            _linkGenerator = httpContextAccessor.HttpContext.RequestServices.GetRequiredService<LinkGenerator>();
            this._uasAppSettings = uasAppSettings;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginUserCommandRequest loginUserCommandRequest)
        {
            var response = await base._mediator.Send(loginUserCommandRequest);
            CheckToken(response);
            if (response.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "email veya şifre hatalı");
                return View(loginUserCommandRequest);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task LogOut()
        {
            await _mediator.Send(new LogOutUserCommandRequest());
            DeleteCookieWithLogOut();
        }


        [HttpGet]
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(PasswordReset passwordReset)
        {
            var response = await _mediator.Send(new PasswordResetCommandRequest { passwordReset = passwordReset });
            if (response.PasswordResetResponse.IsSuccess) { ModelState.AddModelError("", response.PasswordResetResponse.Message); _toastNotification.AddSuccessToastMessage(response.PasswordResetResponse.Message, GetSettingToastr("Başarılı işlem")); }
            if (!response.PasswordResetResponse.IsSuccess) { ModelState.AddModelError("", response.PasswordResetResponse.Message); _toastNotification.AddErrorToastMessage(response.PasswordResetResponse.Message, GetSettingToastr("Hata!")); }
            return View(passwordReset);
        }

        [HttpGet]
        public async Task<IActionResult> ResetPasswordConfirm(string userId, string token)
        {
            return View(new PasswordResetConfirm { UserId = userId, Token = token });
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordConfirm(PasswordResetConfirm passwordResetConfirm)
        {
            var response = await _mediator.Send(new PasswordResetConfirmCommandRequest { PasswordResetConfirm = passwordResetConfirm });
            if (response.PasswordResetConfirmResponse.IsSuccess) { ModelState.AddModelError("", response.PasswordResetConfirmResponse.Message); _toastNotification.AddSuccessToastMessage(response.PasswordResetConfirmResponse.Message, GetSettingToastr("Başarılı işlem")); }
            if (!response.PasswordResetConfirmResponse.IsSuccess) { ModelState.AddModelError("", response.PasswordResetConfirmResponse.Message); _toastNotification.AddErrorToastMessage(response.PasswordResetConfirmResponse.Message, GetSettingToastr("Hata!")); }
            return View(passwordResetConfirm);
        }

        //support methods
        [NonAction]
        private void CheckToken(LoginUserCommandResponse loginUserCommandResponse)
        {
            if (loginUserCommandResponse.Token != null && loginUserCommandResponse.Success)
            {
                SetCookikeAndSignIn(loginUserCommandResponse.Token);
            }
        }
        [NonAction]
        private void SetCookikeAndSignIn(AccessToken accessToken)
        {
            HttpContext.Response.Cookies.Append("X-Access-Token", accessToken.Token, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = accessToken.ExpirationTime
            });
            HttpContext.Response.Cookies.Append("X-Refresh-Token", accessToken.RefreshToken.Token, new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = accessToken.RefreshToken.ExpirationTime
            });
        }
        [NonAction]
        private void DeleteCookieWithLogOut()
        {
            HttpContext.Response.Cookies.Delete("X-Access-Token");
            HttpContext.Response.Cookies.Delete("X-Refresh-Token");
        }
        [NonAction]
        ToastrOptions GetSettingToastr(string title)
        {
            return new ToastrOptions
            {
                Title = title,
                TapToDismiss = true,
                CloseOnHover = true,
                CloseButton = true,
                CloseEasing = true,
                HideDuration = 1,
                ShowDuration = 1,
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                NewestOnTop = true
            };
        }
    }
}

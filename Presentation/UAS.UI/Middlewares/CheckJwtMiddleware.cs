using MediatR;
using Microsoft.AspNetCore.Identity;
using UAS.Application.Abstractions.Token;
using UAS.Application.Features.Commands.AppUser.LogOutUser;
using UAS.Application.Features.Commands.AppUser.RefreshTokenLogin;
using UAS.Domain.Entities;

namespace UAS.UI.Middlewares
{
    public class CheckJwtMiddleware
    {
        private readonly RequestDelegate _next;
        public CheckJwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IDecodeJwtHelper _decodeJwtHelper, IMediator _mediator)
        {
            string? accessToken = context.Request.Cookies["X-Access-Token"];
            string? refreshToken = context.Request.Cookies["X-Refresh-Token"];
            if (accessToken != null)
            {
                bool check = _decodeJwtHelper.DecodeJwt(accessToken);
                if (!check)
                {
                    if(refreshToken == null)
                    {
                        context.Response.Cookies.Delete("X-Access-Token");
                        context.Response.Redirect("/Auth/Index");                        
                        return; //// veya await _next.Invoke(context); kullanılacak
                    }
                    var responseRefreshTokenLogIn = await _mediator.Send(new RefreshTokenLoginCommandRequest { RefreshToken = refreshToken });
                    if(!responseRefreshTokenLogIn.Success)
                    {
                        if (context.User.Identity.IsAuthenticated) await _mediator.Send(new LogOutUserCommandRequest());
                        context.Response.Redirect("/Auth/Index");
                        return; //// veya await _next.Invoke(context); kullanılacak
                    }
                }
            }
            await _next.Invoke(context);
        }
    }
}

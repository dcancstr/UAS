using MediatR;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Auth;
using UAS.Application.Dto.Token;
using UAS.Application.Utilities.Result.Common;

namespace UAS.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            IDataResult<AccessToken> result = await _authService.LoginAsync(new Dto.Auth.LoginUser()
            {
                Password = request.Password,
                UserNameOrEmail = request.UserNameOrEmail,
            });

            return new LoginUserCommandResponse()
            {
                Success = result.Success,
                Message = result.Message,
                Token = result.Data
            };
        }
    }
}

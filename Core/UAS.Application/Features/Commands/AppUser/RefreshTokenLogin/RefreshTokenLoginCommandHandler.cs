using MediatR;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public RefreshTokenLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.RefreshTokenLoginAsync(request.RefreshToken);

            return new RefreshTokenLoginCommandResponse
            {
                Success = result.Success,
                Message = result.Message,
                AccessToken = result.Data
            };
        }
    }
}

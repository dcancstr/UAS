using UAS.Application.Dto.Token;

namespace UAS.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse:CommandBaseResponse
    {
        public AccessToken? AccessToken { get; set; }
    }
}

using UAS.Application.Dto.Token;

namespace UAS.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse : CommandBaseResponse
    {
        public AccessToken? Token { get; set; }
    }
}

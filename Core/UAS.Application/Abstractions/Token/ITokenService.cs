using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.Token;
using UAS.Domain.Entities;

namespace UAS.Application.Abstractions.Token
{
    public interface ITokenService
    {
        AccessToken CreateAccessToken(AppUser user);
        RefreshToken CreateRefreshToken(DateTime accessTokenExpirationtime);
    }
}

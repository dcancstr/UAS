using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Token;
using UAS.Application.Dto.Token;
using UAS.Application.Utilities.Helpers;
using UAS.Domain.Entities;
using System.Security.Claims;
using UAS.EnvironmentConfiguration;

namespace UAS.Infrastructure.Services.Token
{
    public class TokenService : ITokenService
    {
        readonly TokenOptions TokenOptions;

        public TokenService(IOptions<TokenOptions> tokenOptions)
        {
            TokenOptions = tokenOptions.Value;
        }

        public AccessToken CreateAccessToken(AppUser user)
        {
            var securityKey = SecurityKeyHelper.GetSymmetricSecurityKey(EnvironmentConfig.GetAppSetting("TokenOptions:SecurityKey"));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expirationTime = DateTime.UtcNow.AddMinutes((double)TokenOptions.ExpirationTime);
            var securityToken = new JwtSecurityToken
                (
                    issuer: EnvironmentConfig.GetAppSetting("TokenOptions:Issuer"),
                    audience: EnvironmentConfig.GetAppSetting("TokenOptions:Audience"),
                    expires: expirationTime,
                    notBefore: DateTime.UtcNow,
                    signingCredentials: signingCredentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(securityToken);
            var refreshToken = CreateRefreshToken(expirationTime);

            return new AccessToken
            {
                Token = token,
                ExpirationTime = expirationTime,
                RefreshToken = refreshToken
            };
        }

        public RefreshToken CreateRefreshToken(DateTime accessTokenExpirationTime)
        {
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            return new RefreshToken
            {
                Token = token,
                ExpirationTime = accessTokenExpirationTime.AddMinutes(Convert.ToDouble(TokenOptions.ExpirationTime))
            };
        }
    }
}

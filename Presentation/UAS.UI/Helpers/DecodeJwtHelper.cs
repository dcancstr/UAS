using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceStack.Configuration;
using UAS.Application.Abstractions.Token;
using UAS.Application.Dto.Token;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UAS.UI.Models.Configuration;
using UAS.EnvironmentConfiguration;

namespace UAS.UI.Helpers
{
    public class DecodeJwtHelper : IDecodeJwtHelper
    {
        private readonly TokenOptions _options;
        private readonly UASAppSettings appSettings;
        private readonly EnvironmentConfig environmentConfig;

        public DecodeJwtHelper(IOptions<TokenOptions> options, UASAppSettings appSettings, EnvironmentConfig environmentConfig)
        {
            _options = options.Value;
            this.appSettings = appSettings;
            this.environmentConfig = environmentConfig;
        }
        public bool DecodeJwt(string jwt)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(EnvironmentConfig.GetAppSetting("TokenOptions:SecurtiyKey"));
            tokenhandler.ValidateToken(jwt, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateAudience = true,
                ValidAudience = EnvironmentConfig.GetAppSetting("TokenOptions:Audience"),
                ValidateIssuer = true,
                ValidIssuer = EnvironmentConfig.GetAppSetting("TokenOptions:Issuer"),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
            return tokenhandler.CanValidateToken;
        }
    }
}

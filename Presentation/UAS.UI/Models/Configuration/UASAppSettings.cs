using Microsoft.AspNetCore.Identity;
using UAS.EnvironmentConfiguration;

namespace UAS.UI.Models.Configuration
{
    public class UASAppSettings
    {
        private readonly EnvironmentConfig _environmentConfig;

        public UASAppSettings(EnvironmentConfig environmentConfig)
        {
            this._environmentConfig = environmentConfig;
        }
        public string ConnectionString { get => _environmentConfig.GetAppSetting<string>("ConnectionStrings:localDb"); }
        public string LocalDb { get => _environmentConfig.GetAppSetting<string>("ConnectionStrings:localDb"); }
        public int TokenExpirationTime { get => Convert.ToInt32(_environmentConfig.GetAppSetting<string>("TokenOptions:ExpirationTime")); }
        public string Audience { get => _environmentConfig.GetAppSetting<string>("TokenOptions:Audience"); }
        public string Issuer { get => _environmentConfig.GetAppSetting<string>("TokenOptions:Issuer"); }
        public string SecurityKey { get => _environmentConfig.GetAppSetting<string>("TokenOptions:SecurityKey"); }
        public double RefreshTokenExpirationTime { get => Convert.ToDouble(_environmentConfig.GetAppSetting<string>("TokenOptions:RefreshTokenExpirationTime")); }
        public string Azure { get => _environmentConfig.GetAppSetting<string>("Storage:Azure"); }

        public string RedisPort { get => _environmentConfig.GetAppSetting<string>("RedisOptions:Port"); }

    }
}

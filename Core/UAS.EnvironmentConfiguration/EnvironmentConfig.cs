using Microsoft.Extensions.Configuration;


namespace UAS.EnvironmentConfiguration
{
    public class EnvironmentConfig
    {
        public static IConfigurationRoot builderRoot;
        private readonly IConfiguration _conf;
        public EnvironmentConfig(IConfiguration conf)
        {
            this._conf = conf;
        }
        public static string GetAppSetting(string key)
        {
            if (builderRoot == null)
            { 
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builderRoot = builder.Build();
            }            
            return builderRoot.GetSection(key).ToString();
        }
        //Birinci overload ile veri alınamazsa buradaki methodla alınabilir
        public T GetAppSetting<T>(string key)
        {            
            return (T)_conf.GetSection(key).Get(typeof(T));
        }

        public static string GetConnectionString(string key)
        {
            if (builderRoot == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builderRoot = builder.Build();
            }
            return builderRoot.GetConnectionString(key);
        }

        public static List<IConfigurationSection> GetConfigArray(string key)
        {
            if (builderRoot == null)
            {
                var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                builderRoot = builder.Build();
            }
            var res = builderRoot.GetSection(key).GetChildren().ToList();
            return builderRoot.GetSection(key).GetChildren().ToList();
        }
    }
}


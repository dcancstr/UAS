using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UAS.Persistence
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Core/UAS.EnvironmentConfiguration"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("localDb");

            }
        }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.EnvironmentConfiguration;

namespace UAS.Domain.Entities.Configuration
{
    public class UASServerConfiguration
    {
        
        public TokenOptions TokenOptions { get => new TokenOptions
        {
           AuthenticatorIssuer = EnvironmentConfig.GetAppSetting("TokenOptions:Issuer"),
        };}
        public string  ConnectionString { get => EnvironmentConfig.GetAppSetting("ConnectionStrings:UASApiDB");}
    }
}

    using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services.Configurations;
using UAS.Application.Abstractions.Storage;
using UAS.Application.Abstractions.Token;
using UAS.Application.Dto.Token;
using UAS.Application.Utilities.Helpers;
using UAS.Infrastructure.Extensions;
using UAS.Infrastructure.Services.Configurations;
using UAS.Infrastructure.Services.Storage;
using UAS.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using UAS.Application.Abstractions.Email;
using UAS.Infrastructure.Services.Email;
using UAS.EnvironmentConfiguration;

namespace UAS.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration Configuration, EnvironmentConfig environmentConfiguration)
        {
            services.AddScoped<IApplicationService, ApplicationService>();

            var TokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            services.AddAuthentication();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Auth/Index");
                options.LogoutPath = new PathString("/Auth/LogOut");
                options.AccessDeniedPath = new PathString("/Auth/Index");
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.SlidingExpiration = false;

                options.Cookie.Name = "OS";
                options.Cookie.HttpOnly = true;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.SameSite = SameSiteMode.Strict;

            });
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,

            //            ValidAudience = TokenOptions.Audience,
            //            ValidIssuer = TokenOptions.Issuer,
            //            IssuerSigningKey = SecurityKeyHelper.GetSymmetricSecurityKey(TokenOptions.SecurityKey)
            //        };
            //    });

            services.AddTokenService(options =>
            {
                options.Audience = environmentConfiguration.GetAppSetting<string>("TokenOptions:Audience");
                options.Issuer = environmentConfiguration.GetAppSetting<string>("TokenOptions:Issuer");
                options.ExpirationTime = Convert.ToInt32(environmentConfiguration.GetAppSetting<string>("TokenOptions:ExpirationTime"));
                options.SecurityKey = environmentConfiguration.GetAppSetting<string>("TokenOptions:SecurityKey");
                options.RefreshTokenExpirationTime = Convert.ToInt32(environmentConfiguration.GetAppSetting<string>("TokenOptions:RefreshTokenExpirationTime"));
            });

            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<IMailService, MailService>();

        }
        public static void AddStorage<T>(this IServiceCollection serviceCollection) where T : class, IStorage
        {
            serviceCollection.AddScoped<IStorage, T>();
        }
    }
}

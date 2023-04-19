using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using UAS.Application.Abstractions.Token;
using UAS.Application.Dto.Token;
using UAS.EnvironmentConfiguration;
using UAS.UI.CustomAuthorize;
using UAS.UI.Helpers;
using UAS.UI.Models.Configuration;

namespace UAS.UI
{
    public static class ServiceRegistration
    {
        public static void AddUIServices(this IServiceCollection services, IConfiguration Configuration, EnvironmentConfig environmentConfig)
        {
            // options pattern
            services.Configure<TokenOptions>(Configuration.GetSection("TokenOptions"));
            services.AddTransient<IDecodeJwtHelper, DecodeJwtHelper>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();           
            services.AddSingleton<UASAppSettings>();
            services.AddSingleton<EnvironmentConfig>();

            // custom authorization with policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AllowedControllerActions", policy =>
                {

                    policy.Requirements.Add(new AllowedControllersRequirement(new List<string>
                    {
                        "KullaniciLookup:KullaniciEkle",
                        "KullaniciLookup:KullaniciGuncelle",
                        "KullaniciLookup:SilinmisKullanicilar",
                        "KullaniciLookup:KullaniciRolAtama",
                        "Rol:RolEkle",
                        "Rol:RolGuncelle",
                        "Settings:SiteSettings",
                        "Settings:AddPageMenuPanel",
                        "Home:Index",
                    }));
                });
            });
            services.AddScoped<AllowedControllersHandler>();
            services.AddScoped<IAuthorizationHandler>(sp =>
            {
                return sp.GetRequiredService<AllowedControllersHandler>();
            });

            services.AddStackExchangeRedisCache(options => options.Configuration = environmentConfig.GetAppSetting<string>("RedisOptions:Port"));
            services.AddMemoryCache();


        }
    }
}

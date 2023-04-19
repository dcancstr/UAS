using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Token;
using UAS.Infrastructure.Services.Token;

namespace UAS.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTokenService(this IServiceCollection services, Action<UAS.Application.Dto.Token.TokenOptions> options)
        {
            services.AddScoped<ITokenService, TokenService>();
            //services.Configure(options);
        }
    }
}

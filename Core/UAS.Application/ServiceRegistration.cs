using MediatR;
using Microsoft.Extensions.DependencyInjection;
using UAS.Application.Dto.SiteSettings;
using System.Reflection;
using UAS.Domain.Entities.Configuration;
using UAS.Application.Abstractions.Services;
using RabbitMQ.Client;
using UAS.Application.Abstractions.Services.RabbitMqServices;
using UAS.Application.RabbitMqServices.ClientServices;
using UAS.Application.RabbitMqServices.Publishers;

namespace UAS.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            var serverConf = new UASServerConfiguration();
            services.AddSingleton(serverConf);

            services.AddSingleton(sp => new ConnectionFactory() { HostName = "localhost", Port = 5000, DispatchConsumersAsync = true });
            services.AddSingleton<IRabbitMqClientService, RabbitMqClientService>();
            services.AddSingleton<IRabbitMqExcelCreatePublisher, RabbitMqExcelCreatePublisher>();
        }
    }
}
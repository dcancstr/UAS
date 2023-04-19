using CreateMenuPanelExcel;
using CreateMenuPanelExcel.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using UAS.Application.Abstractions.Services;
using UAS.Persistence.Contexts;
using UAS.Persistence.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton(sp => new ConnectionFactory() { HostName = "localhost", Port = 5000, DispatchConsumersAsync = true });
        services.AddSingleton<RabbitMqClientService>();
        services.AddDbContext<UASDbContext>(opt => opt.UseSqlServer(hostContext.Configuration.GetConnectionString("localDb")));
    })
    .Build();

await host.RunAsync();

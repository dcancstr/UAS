using ClosedXML.Excel;
using CreateMenuPanelExcel.Services;
using Microsoft.AspNetCore.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Data;
using System.Text;
using System.Text.Json;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.User;
using UAS.Application.EventAndMessages;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;
using UAS.Persistence.Services;

namespace CreateMenuPanelExcel
{
    public class Worker : BackgroundService
    {
        private readonly IConfiguration _configuration;
        private readonly RabbitMqClientService _rabbitMqClientService;
        private readonly IServiceProvider _serviceProvider;
        private IModel _channel;
        public Worker(IConfiguration configuration, IServiceProvider serviceProvider, RabbitMqClientService rabbitMqClientService)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _rabbitMqClientService = rabbitMqClientService;
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitMqClientService.Connect();
            _channel.BasicQos(0, 1, false);
            return base.StartAsync(cancellationToken);
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            _channel.BasicConsume(RabbitMqClientService.QueueName, false, consumer);
            consumer.Received += Consumer_Received1;
        }

        private Task Consumer_Received1(object sender, BasicDeliverEventArgs @event)
        {

            JsonSerializer.Deserialize<UserListExcelCreatedEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));
            var wb = new XLWorkbook();
            var ds = new DataSet();
            ds.Tables.Add(GetTable("Users"));
            wb.Worksheets.Add(ds);
            var fileName = Guid.NewGuid().ToString() + ".xlsx";
            string path = "UasExcelTest";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.OpenOrCreate))
                wb.SaveAs(stream); 
            _channel.BasicAck(@event.DeliveryTag, false);
            return Task.CompletedTask;
        }


        private DataTable GetTable(string tableName)
        {
            List<ListUser> users = new();
            using (var scope = _serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<UASDbContext>();
                var liste = context.Users.ToList();
                liste.ForEach(x => users.Add(new ListUser { Email = x.Email, Id = x.Id, Name = x.Name, Surname = x.Surname, UserName = x.UserName }));
            }
            DataTable dataTable = new DataTable() { TableName = tableName };
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            dataTable.Columns.Add("UserName", typeof(string));
            users.ForEach(x => dataTable.Rows.Add(x.Id, x.Email, x.Name, x.Surname, x.UserName));
            return dataTable;
        }
    }
}
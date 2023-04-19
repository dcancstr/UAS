using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using UAS.Application.Abstractions.Services.RabbitMqServices;
using UAS.Application.EventAndMessages;
using UAS.Application.RabbitMqServices.ClientServices;

namespace UAS.Application.RabbitMqServices.Publishers
{
    public class RabbitMqExcelCreatePublisher : IRabbitMqExcelCreatePublisher
    {
        private readonly IRabbitMqClientService _rabbitMqClientService;
        public RabbitMqExcelCreatePublisher(IRabbitMqClientService rabbitMqClientService)
        {
            _rabbitMqClientService = rabbitMqClientService;
        }

        public void Publish(UserListExcelCreatedEvent userListExcelCreatedEvent)
        {
            var channel = _rabbitMqClientService.Connect();
            var bodyString = JsonSerializer.Serialize(userListExcelCreatedEvent);
            var bodyByte = Encoding.UTF8.GetBytes(bodyString);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            channel.BasicPublish(RabbitMqClientService.ExchangeName, RabbitMqClientService.RoutingName, properties, bodyByte);
        }
    }
}

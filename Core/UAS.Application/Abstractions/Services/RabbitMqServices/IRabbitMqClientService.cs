using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Abstractions.Services.RabbitMqServices
{
    public interface IRabbitMqClientService
    {
        IModel Connect();
        void Dispose();
    }
}

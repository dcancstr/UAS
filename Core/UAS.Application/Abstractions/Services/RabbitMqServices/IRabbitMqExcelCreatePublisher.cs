using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.EventAndMessages;

namespace UAS.Application.Abstractions.Services.RabbitMqServices
{
    public interface IRabbitMqExcelCreatePublisher
    {
        public void Publish(UserListExcelCreatedEvent userListExcelCreatedEvent);
    }
}

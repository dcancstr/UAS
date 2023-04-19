using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Features.Commands;
using UAS.Domain.Entities;

namespace UAS.Application.Features.Queries.Notification.GetAllNotification
{
    public class GetAllNotificationQueryResponse : CommandBaseResponse
    {
        public int TotalNotificationCount { get; set; }
        public object Notifications { get; set; }
    }
}

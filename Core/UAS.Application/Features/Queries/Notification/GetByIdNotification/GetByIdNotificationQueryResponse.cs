using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Features.Commands;
using UAS.Domain.Entities;

namespace UAS.Application.Features.Queries.Notification.GetByIdNotification
{
    public class GetByIdNotificationQueryResponse : CommandBaseResponse
    {
        
        public string? Text { get; set; }
        public string? SmsText { get; set; }
        public string? Url { get; set; }
        public bool? Visible { get; set; }


        public Domain.Entities.NotificationCategory? NotificationCategory { get; set; }
        //public string? NotificationCatName { get; set; }
        public Domain.Entities.AppUser? User { get; set; }
    }
}

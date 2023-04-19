using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.Notification.CreateNotificationCommand
{
    public class CreateNotificationCommandRequest : IRequest<CreateNotificationCommandResponse>
    {
        //public int NotificationCategoryId { get; set; }
        //public int UserId { get; set; }
        public string Text { get; set; }
        public string SmsText { get; set; }
        public string Url { get; set; }
    }
}

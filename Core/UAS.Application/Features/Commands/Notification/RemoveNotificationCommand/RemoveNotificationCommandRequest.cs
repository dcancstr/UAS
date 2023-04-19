using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.Notification.RemoveNotificationCommand
{
    public class RemoveNotificationCommandRequest : IRequest<RemoveNotificationCommandResponse>
    {
        public int Id { get; set; }
    }
}

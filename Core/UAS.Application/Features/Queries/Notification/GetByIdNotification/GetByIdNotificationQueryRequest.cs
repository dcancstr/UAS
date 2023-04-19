using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.Notification.GetByIdNotification
{
    public class GetByIdNotificationQueryRequest : IRequest<GetByIdNotificationQueryResponse>   
    {
        public int Id { get; set; }
    }
}

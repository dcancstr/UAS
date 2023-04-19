using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.NotificationCategory.GetByIdNotificationCategory
{
    public class GetByIdNotificationCategoryRequest : IRequest<GetByIdNotificationCategoryResponse>
    {
        public int Id { get; set; }
    }
}

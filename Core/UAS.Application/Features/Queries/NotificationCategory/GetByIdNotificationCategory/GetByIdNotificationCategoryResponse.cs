using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.NotificationCategory.GetByIdNotificationCategory
{
    public class GetByIdNotificationCategoryResponse
    {
        public string? Name { get; set; }

        public string? MailTheme { get; set; }

        public string? BackgroundColor { get; set; }

        public bool? ShownOnPanel { get; set; } = true;

        public ICollection<Domain.Entities.Notification>? Notifications { get; set; }
    }
}

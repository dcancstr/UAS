using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class NotificationCategory : BaseEntity<int>
    {
        public string? Name { get; set; }

        public string? MailTheme { get; set; }

        public string? BackgroundColor { get; set; }

        public bool? ShownOnPanel { get; set; } = true;

        public ICollection<Notification>? Notifications { get; set; }
    }
}

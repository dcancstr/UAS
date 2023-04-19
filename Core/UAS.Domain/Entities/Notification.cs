using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class Notification : BaseEntity<int>
    {
        public int? NotificationCategoryId { get; set; }
        public int? UserId { get; set; }

        public string? Text { get; set; }
        public string? SmsText { get; set; }
        public string? Url { get; set; }
        public bool? Visible { get; set; } = true;


        public NotificationCategory? NotificationCategory { get; set; }
        //public AppUser? User { get; set; }

    }
}

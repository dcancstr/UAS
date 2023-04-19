using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Notification.UpdateNotification
{
    public class UpdateNotification
    {
        
        public int Id { get; set; }
        //public int? NotificationCategoryId { get; set; }
        //public int? UserId { get; set; }

        public string Text { get; set; }
        public string SmsText { get; set; }
        public string Url { get; set; }
    }
}

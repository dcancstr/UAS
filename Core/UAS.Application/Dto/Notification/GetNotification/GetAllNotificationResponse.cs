using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.Common;

namespace UAS.Application.Dto.Notification.GetNotification
{
    public class GetAllNotificationResponse : BaseResponse
    {
        public int TotalNotificationCount { get; set; }
        public object Notifications { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Repositories.Notification;
using UAS.Persistence.Contexts;

namespace UAS.Persistence.Repositories.Notification
{
    public class NotificationWriteRepository : WriteRepository<Domain.Entities.Notification,int>, INotificationWriteRepository
    {
        public NotificationWriteRepository(UASDbContext context) : base(context)
        {
        }
    }
}

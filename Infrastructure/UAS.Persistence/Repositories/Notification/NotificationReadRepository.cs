using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Repositories.Notification;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;

namespace UAS.Persistence.Repositories.Notification
{
    public class NotificationReadRepository : ReadRepository<Domain.Entities.Notification,int>, INotificationReadRepository
    {
        public NotificationReadRepository(UASDbContext context) : base(context)
        {
        }
    }
}

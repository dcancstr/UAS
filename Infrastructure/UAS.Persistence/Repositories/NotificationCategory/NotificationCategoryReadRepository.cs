using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Repositories.NotificationCategory;
using UAS.Persistence.Contexts;

namespace UAS.Persistence.Repositories.NotificationCategory
{
    public class NotificationCategoryReadRepository : ReadRepository<Domain.Entities.NotificationCategory,int>, INotificationCategoryReadRepository
    {
        public NotificationCategoryReadRepository(UASDbContext context) : base(context)
        {
        }
    }
}

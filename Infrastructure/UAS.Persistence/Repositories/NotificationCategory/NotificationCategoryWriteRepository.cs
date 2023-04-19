using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Repositories;
using UAS.Application.Repositories.NotificationCategory;
using UAS.Persistence.Contexts;

namespace UAS.Persistence.Repositories.NotificationCategory
{
    public class NotificationCategoryWriteRepository : WriteRepository<Domain.Entities.NotificationCategory,int>, INotificationCategoryWriteRepository
    {
        public NotificationCategoryWriteRepository(UASDbContext context) : base(context)
        {
        }
    }
}

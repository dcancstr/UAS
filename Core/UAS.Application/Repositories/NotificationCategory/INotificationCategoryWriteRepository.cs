using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Repositories.NotificationCategory
{
    public interface INotificationCategoryWriteRepository : IWriteRepository<Domain.Entities.NotificationCategory,int>
    {
    }
}

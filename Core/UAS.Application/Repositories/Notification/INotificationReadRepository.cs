using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Domain.Entities;

namespace UAS.Application.Repositories.Notification
{
    public interface INotificationReadRepository : IReadRepository<Domain.Entities.Notification,int>
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Domain.Entities;

namespace UAS.Application.Repositories
{
    public interface ISiteSettingWriteRepository : IWriteRepository<SiteSetting, int>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Repositories;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;

namespace UAS.Persistence.Repositories
{
    public class SiteSettingReadRepository : ReadRepository<SiteSetting, int>, ISiteSettingReadRepository
    {
        public SiteSettingReadRepository(UASDbContext context) : base(context)
        {
        }
    }
}

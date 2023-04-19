using UAS.Application.Repositories.PersonelRolTip;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories.PersonelRolTip
{
    public class PersonelRolTipReadRepository : ReadRepository<UAS.Domain.Entities.PersonelRolTip, int>, IPersonelRolTipReadRepository
    {
        public PersonelRolTipReadRepository(UASDbContext context) : base(context)
        {
        }
    }
}

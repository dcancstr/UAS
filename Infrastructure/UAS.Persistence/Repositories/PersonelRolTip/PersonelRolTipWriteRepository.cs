using UAS.Application.Repositories.PersonelRolTip;
using UAS.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories.PersonelRolTip
{
    public class PersonelRolTipWriteRepository : WriteRepository<UAS.Domain.Entities.PersonelRolTip, int>, IPersonelRolTipWriteRepository
    {
        public PersonelRolTipWriteRepository(UASDbContext context) : base(context)
        {
        }
    }
}

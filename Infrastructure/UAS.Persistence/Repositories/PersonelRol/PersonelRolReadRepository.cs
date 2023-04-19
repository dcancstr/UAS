using UAS.Application.Repositories.PersonelRol;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories.PersonelRol
{
    public class PersonelRolReadRepository : ReadRepository<UAS.Domain.Entities.PersonelRol, int>, IPersonelRolReadRepository
    {
        public PersonelRolReadRepository(UASDbContext context) : base(context)
        {
        }
    }
}

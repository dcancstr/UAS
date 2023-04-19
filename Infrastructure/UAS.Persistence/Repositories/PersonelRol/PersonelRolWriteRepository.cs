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
    public class PersonelRolWriteRepository : WriteRepository<UAS.Domain.Entities.PersonelRol, int>, IPersonelRolWriteRepository
    {
        public PersonelRolWriteRepository(UASDbContext context) : base(context)
        {
        }
    }
}

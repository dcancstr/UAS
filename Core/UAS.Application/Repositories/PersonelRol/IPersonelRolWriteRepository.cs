using UAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Repositories;

namespace UAS.Application.Repositories.PersonelRol
{
    public interface IPersonelRolWriteRepository : IWriteRepository<UAS.Domain.Entities.PersonelRol, int>
    {
    }
}

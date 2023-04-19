using UAS.Application.Repositories.MenuKategori;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories.MenuKategori
{
    public class MenuKategoriWriteRepository : WriteRepository<UAS.Domain.Entities.MenuKategori, int>, IMenuKategoriWriteRepository
    {
        public MenuKategoriWriteRepository(UASDbContext context) : base(context)
        {
        }
    }
}

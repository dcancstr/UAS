using UAS.Application.Repositories.GrupMenuPanel;
using UAS.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories.GrupMenuPanel
{
    public class GrupMenuPanelWriteRepository : WriteRepository<UAS.Domain.Entities.GrupMenuPanel, int>, IGrupMenuPanelWriteRepository
    {
        public GrupMenuPanelWriteRepository(UASDbContext context) : base(context)
        {
        }
    }
}

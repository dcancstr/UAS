using UAS.Application.Repositories.MenuPanel;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories.MenuPanel
{
    public class MenuPanelWriteRepository : WriteRepository<UAS.Domain.Entities.MenuPanel, int>, IMenuPanelWriteRepository
    {
        public MenuPanelWriteRepository(UASDbContext context) : base(context)
        {
        }
    }
}

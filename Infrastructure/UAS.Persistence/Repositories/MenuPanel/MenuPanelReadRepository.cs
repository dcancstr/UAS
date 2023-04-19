using UAS.Application.Repositories.MenuPanel;
using UAS.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.Repositories.MenuPanel
{
    public class MenuPanelReadRepository : ReadRepository<UAS.Domain.Entities.MenuPanel, int>, IMenuPanelReadRepository
    {
        public MenuPanelReadRepository(UASDbContext context) : base(context)
        {
        }
    }
}

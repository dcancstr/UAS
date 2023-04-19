using UAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Repositories.GrupMenuPanel
{
    public interface IGrupMenuPanelReadRepository : IReadRepository<UAS.Domain.Entities.GrupMenuPanel, int>
    {
        Task<(List<UAS.Domain.Entities.MenuPanel>, List<UAS.Domain.Entities.MenuKategori>)> GetMenuPanelsAndMenukategoriWithUserName(string userName);

    }
}

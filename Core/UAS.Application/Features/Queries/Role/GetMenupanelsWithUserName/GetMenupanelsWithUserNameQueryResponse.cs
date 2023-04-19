using UAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.Role.GetMenupanelsWithUserName
{
    public class GetMenupanelsWithUserNameQueryResponse
    {
        public List<MenuPanel> MenuPanels { get; set; }
        public List<MenuKategori> MenuKategories { get; set; }
    }
}

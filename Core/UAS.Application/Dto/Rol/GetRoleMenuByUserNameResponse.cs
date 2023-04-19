using UAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Rol
{
    public class GetRoleMenuByUserNameResponse
    {
        public List<MenuPanel> MenuPanels { get; set; }
        public List<MenuKategori> MenuKategories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Domain.Entities;

namespace UAS.Application.Dto.RedisCache
{
    public class RedisGetUserMenus
    {
        public List<MenuPanel> MenuPanels { get; set; }
        public List<MenuKategori> MenuKategories { get; set; }
    }
}

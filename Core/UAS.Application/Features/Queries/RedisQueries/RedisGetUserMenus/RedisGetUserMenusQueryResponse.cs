using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Domain.Entities;

namespace UAS.Application.Features.Queries.RedisQueries.RedisGetUserMenus
{
    public class RedisGetUserMenusQueryResponse
    {
        public List<MenuPanel> MenuPanels { get; set; }
        public List<MenuKategori> MenuKategories { get; set; }
    }
}

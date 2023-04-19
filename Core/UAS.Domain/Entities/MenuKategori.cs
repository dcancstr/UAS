using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class MenuKategori : BaseEntity<int>
    {
        public string menuKategoriAd { get; set; }
        public int menuKategoriSira { get; set; }
        //Relational Properties
        public ICollection<MenuPanel> MenuPanels { get; set; }
    }
}

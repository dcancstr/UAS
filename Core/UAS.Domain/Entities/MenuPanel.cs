using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class MenuPanel : BaseEntity<int>
    {
        public int menuUstID { get; set; }
        public int menuSira { get; set; }
        public string menuIcon { get; set; }
        public string menuAd { get; set; }
        public string menuLink { get; set; }
        public bool menuVisible { get; set; }
        public bool menuSMI { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }



        //Relational Properties
        public int menuKategoriID { get; set; }
        public MenuKategori MenuKategori { get; set; }

        //public ICollection<GrupMenuPanel> GrupMenuPanels { get; set; }
    }
}

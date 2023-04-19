using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class GrupMenuPanel : BaseEntity<int>
    {
        public bool grupMenuSMI { get; set; }


        //Relational Properties
         
        //public MenuPanel MenuPanel { get; set; }
        public int menuID { get; set; }


        //public PersonelRolTip PersonelRolTip { get; set; }
        public int personelRolTipID { get; set; }
    }
}

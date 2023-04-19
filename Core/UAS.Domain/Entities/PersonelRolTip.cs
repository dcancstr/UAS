using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class PersonelRolTip : BaseEntity<int>
    {
        public string personelRolTipAd { get; set; }
        public bool personelRolTipSMI { get; set; }
        public string personelRolTipColor { get; set; }
        public int personelRolTipIndexUrl { get; set; }

        //Relational Properties
        //public ICollection<GrupMenuPanel> GrupMenuPanels { get; set; }
        public ICollection<PersonelRol> PersonelRols { get; set; }
    }
}

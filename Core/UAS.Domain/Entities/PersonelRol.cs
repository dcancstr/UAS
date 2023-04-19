using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class PersonelRol : BaseEntity<int>
    {
        public bool personelRolSMI { get; set; }
        public int personelRolSira { get; set; }

        // relation properties
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int personelRolTipID { get; set; }
        public PersonelRolTip PersonelRolTip { get; set; }
    }
}

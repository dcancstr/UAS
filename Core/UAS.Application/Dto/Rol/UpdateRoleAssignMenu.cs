using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Rol
{
    public class UpdateRoleAssignMenu
    {
        public int Id { get; set; }
        public string menuAd { get; set; }
        public int menuUstID { get; set; }
        public bool IsChecked { get; set; }
    }
}

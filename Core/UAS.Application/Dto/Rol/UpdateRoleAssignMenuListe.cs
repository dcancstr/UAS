using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Rol
{
    public class UpdateRoleAssignMenuListe
    {
        public List<UpdateRoleAssignMenu> UpdateRoleAssignMenus { get; set; }
        public List<UpdateRoleAssignMenuGetRoles> UpdateRoleAssignMenuGetRoles { get; set; }
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }
        public int RoleId { get; set; }
        public bool IsSuccess { get; set; }
    }
}

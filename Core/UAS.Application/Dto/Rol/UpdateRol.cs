using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Rol
{
    public class UpdateRol
    {
        public List<RoleMenuListPermission> permissionList { get; set; }
        public bool isRoledeleted { get; set; }
        public string roleName { get; set; }
        public int roleId { get; set; }
    }

    public class RoleMenuListPermission
    {
        public bool isChecked { get; set; }
        public int permissionId { get; set; }
    }
}

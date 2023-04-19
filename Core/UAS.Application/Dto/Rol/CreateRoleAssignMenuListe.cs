using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Rol
{
    public class CreateRoleAssignMenuListe
    {
        public List<CreateRoleAssignMenu> CreateRoleAssignMenus { get; set; }
        public string RoleName { get; set; }
    }
}

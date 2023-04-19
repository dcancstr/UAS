using MediatR;
using UAS.Application.Dto.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.Role.CreateRolAssingMenuPanel
{
    public class CreateRolAssingMenuPanelCommandRequest : IRequest<CreateRolAssingMenuPanelCommandResponse>
    {
        public CreateRoleAssignMenuListe CreateRoleAssignMenuListe { get; set; }
    }
}

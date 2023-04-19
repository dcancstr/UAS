using MediatR;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.Role.CreateRolAssingMenuPanel
{
    public class CreateRolAssingMenuPanelCommandHandler : IRequestHandler<CreateRolAssingMenuPanelCommandRequest, CreateRolAssingMenuPanelCommandResponse>
    {
        private readonly IRoleService _roleService;
        public CreateRolAssingMenuPanelCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRolAssingMenuPanelCommandResponse> Handle(CreateRolAssingMenuPanelCommandRequest request, CancellationToken cancellationToken)
        {
            return new CreateRolAssingMenuPanelCommandResponse { IsSuccess = await _roleService.CreateRoleAndAssignMenuPanel(request.CreateRoleAssignMenuListe) };
        }
    }
}

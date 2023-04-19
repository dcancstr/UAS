using MediatR;
using UAS.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.Role.UpdateRoleOfMenuPanels
{
    public class UpdateRoleOfMenuPanelsQueryHandler : IRequestHandler<UpdateRoleOfMenuPanelsQueryRequest, UpdateRoleOfMenuPanelsQueryResponse>
    {
        private readonly IRoleService _roleService;
        public UpdateRoleOfMenuPanelsQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleOfMenuPanelsQueryResponse> Handle(UpdateRoleOfMenuPanelsQueryRequest request, CancellationToken cancellationToken)
        {
            return new UpdateRoleOfMenuPanelsQueryResponse { UpdateRoleAssignMenuListe = await _roleService.UpdateRolGetRoles() };
        }
    }
}

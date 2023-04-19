using MediatR;
using UAS.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.Role.UpdateRoleGetMenuPanels
{
    public class UpdateRoleGetMenuPanelsQueryHandler : IRequestHandler<UpdateRoleGetMenuPanelsQueryRequest, UpdateRoleGetMenuPanelsQueryResponse>
    {
        private readonly IRoleService _roleService;
        public UpdateRoleGetMenuPanelsQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRoleGetMenuPanelsQueryResponse> Handle(UpdateRoleGetMenuPanelsQueryRequest request, CancellationToken cancellationToken)
        {
            return new UpdateRoleGetMenuPanelsQueryResponse
            {
                UpdateRoleAssignMenuListe = await _roleService.UpdateRoleAndGetPersonelTipAndMenuPanel(request.UpdateRoleAssignMenuListe)
            };
        }
    }
}

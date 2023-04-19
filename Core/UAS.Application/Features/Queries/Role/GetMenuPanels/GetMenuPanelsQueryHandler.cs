using MediatR;
using UAS.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.Role.GetMenuPanels
{
    public class GetMenuPanelsQueryHandler : IRequestHandler<GetMenuPanelsQueryRequest, GetMenuPanelsQueryResponse>
    {
        private readonly IRoleService _roleService;
        public GetMenuPanelsQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetMenuPanelsQueryResponse> Handle(GetMenuPanelsQueryRequest request, CancellationToken cancellationToken)
        {
            return new GetMenuPanelsQueryResponse { CreateRoleAssignMenuListe = await _roleService.GetMenuPanels() };
        }
    }
}

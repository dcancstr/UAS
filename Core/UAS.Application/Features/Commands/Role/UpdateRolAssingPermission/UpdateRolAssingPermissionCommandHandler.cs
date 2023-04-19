using MediatR;
using Newtonsoft.Json;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.Role.UpdateRolAssingPermission
{
    public class UpdateRolAssingPermissionCommandHandler : IRequestHandler<UpdateRolAssingPermissionCommandRequest, UpdateRolAssingPermissionCommandResponse>
    {
        private readonly IRoleService _roleService;
        public UpdateRolAssingPermissionCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<UpdateRolAssingPermissionCommandResponse> Handle(UpdateRolAssingPermissionCommandRequest request, CancellationToken cancellationToken)
        {
            return new UpdateRolAssingPermissionCommandResponse
            {
                UpdateRoleAssignMenuListe = await _roleService.UpdateRoleAndGetPersonelTip(JsonConvert.DeserializeObject<UpdateRol>(request.Data))
            };
        }
    }
}

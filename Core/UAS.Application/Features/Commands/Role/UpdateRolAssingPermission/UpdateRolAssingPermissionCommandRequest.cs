using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.Role.UpdateRolAssingPermission
{
    public class UpdateRolAssingPermissionCommandRequest : IRequest<UpdateRolAssingPermissionCommandResponse>
    {
        public string Data { get; set; }
    }
}

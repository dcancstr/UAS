using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Commands.Role.AddMenuPanels
{
    public class AddMenuPanelsCommandHandler : IRequestHandler<AddMenuPanelsCommandRequest, AddMenuPanelsCommandResponse>
    {
        private readonly IRoleService _roleService;
        public AddMenuPanelsCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<AddMenuPanelsCommandResponse> Handle(AddMenuPanelsCommandRequest request, CancellationToken cancellationToken)
        {
            return new AddMenuPanelsCommandResponse { IsSuccess = await _roleService.AddMenuPanels(request.model) };
        }
    }
}

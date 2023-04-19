using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Commands.Role.AddPersonelRol
{
    public class AddPersonelRolCommandHandler : IRequestHandler<AddPersonelRolCommandRequest, AddPersonelRolCommandResponse>
    {
        IRoleService _roleService;
        IMapper _mapper;
        public AddPersonelRolCommandHandler(IRoleService roleService,IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        public async Task<AddPersonelRolCommandResponse> Handle(AddPersonelRolCommandRequest request, CancellationToken cancellationToken)
        {
            var addPersonelRol = _mapper.Map<Dto.Rol.AddPersonelRol>(request);
            var result = await _roleService.AddOrUpdatePersonelRol(addPersonelRol);
            return new()
            {
                Success = result
            };
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Queries.Role.UpdatePersonelRolGetUsers
{
    public class UpdatePersonelRolGetUsersQueryHandler : IRequestHandler<UpdatePersonelRolGetUsersQueryRequest, UpdatePersonelRolGetUsersQueryResponse>
    {
        IRoleService _roleService;
        IMapper _mapper;

        public UpdatePersonelRolGetUsersQueryHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        public async Task<UpdatePersonelRolGetUsersQueryResponse> Handle(UpdatePersonelRolGetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _roleService.UpdatePersonelRolGetUsers();
            return new() { Data = response };
        }
    }
}

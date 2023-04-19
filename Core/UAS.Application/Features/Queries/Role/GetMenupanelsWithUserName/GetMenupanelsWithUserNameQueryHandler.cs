using AutoMapper;
using MediatR;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.Role.GetMenupanelsWithUserName
{
    public class GetMenupanelsWithUserNameQueryHandler : IRequestHandler<GetMenupanelsWithUserNameQueryRequest, GetMenupanelsWithUserNameQueryResponse>
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public GetMenupanelsWithUserNameQueryHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public async Task<GetMenupanelsWithUserNameQueryResponse> Handle(GetMenupanelsWithUserNameQueryRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetRoleMenuByUserNameResponse, GetMenupanelsWithUserNameQueryResponse>(await _roleService.GetMenuPanelsAndMenukategoriWithUserName(_mapper.Map<GetMenupanelsWithUserNameQueryRequest, GetRoleMenuByUserName>(request)));
        }
    }
}

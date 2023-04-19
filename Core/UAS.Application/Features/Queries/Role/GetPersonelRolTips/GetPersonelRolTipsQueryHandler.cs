using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Queries.Role.GetPersonelRolTips
{
    public class GetPersonelRolTipsQueryHandler : IRequestHandler<GetPersonelRolTipsQueryRequest, GetPersonelRolTipsQueryResponse>
    {
        IRoleService _roleService;
        IMapper _mapper;
        public GetPersonelRolTipsQueryHandler(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }
        public async Task<GetPersonelRolTipsQueryResponse> Handle(GetPersonelRolTipsQueryRequest request, CancellationToken cancellationToken)
        {
            var x = _roleService.GetPersonelRolTips();
            return new() { Data =  x};
        }
    }
}

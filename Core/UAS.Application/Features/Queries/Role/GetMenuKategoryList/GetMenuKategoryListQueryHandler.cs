using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Queries.Role.GetMenuKategoryList
{
    public class GetMenuKategoryListQueryHandler : IRequestHandler<GetMenuKategoryListQueryRequest, GetMenuKategoryListQueryReponse>
    {
        private readonly IRoleService _roleService;
        public GetMenuKategoryListQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<GetMenuKategoryListQueryReponse> Handle(GetMenuKategoryListQueryRequest request, CancellationToken cancellationToken)
        {
            return new GetMenuKategoryListQueryReponse { GetMenuKategories = _roleService.GetMenuCategories() };
        }
    }
}

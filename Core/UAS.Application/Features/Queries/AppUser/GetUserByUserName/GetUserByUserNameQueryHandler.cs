using MediatR;
using UAS.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.AppUser.GetUserByUserName
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQueryRequest, GetUserByUserNameQueryResponse>
    {
        private readonly IUserService _userService;
        public GetUserByUserNameQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserByUserNameQueryResponse> Handle(GetUserByUserNameQueryRequest request, CancellationToken cancellationToken)
        {
            return new GetUserByUserNameQueryResponse { GetUserResponse = await _userService.GetByUserName(request.GetUser) };
        }
    }
}

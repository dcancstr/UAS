using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Queries.AppUser.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest,GetUserByIdQueryResponse>
    {

            private readonly IUserService _userService;
            public GetUserByIdQueryHandler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
            {
                return new GetUserByIdQueryResponse { GetUserResponse = await _userService.GetById(request.Id) };
            }

    }
}

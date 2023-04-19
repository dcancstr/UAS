using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Queries.AppUser.GetlDeletedUsers
{
    public class GetDeletedUsersQueryHandler : IRequestHandler<GetDeletedUsersQueryRequest,GetDeletedUsersQueryResponse>
    {
        readonly IUserService _userService;
        public GetDeletedUsersQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<GetDeletedUsersQueryResponse> Handle(GetDeletedUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetDeletedUsersAsync();
            return new()
            {
                Users = users,
                TotalUsersCount = users.Data.Count(),
                Message = Constans.Message.GetAllUserSuccess,
                Success = true
            };
        }
    }
}

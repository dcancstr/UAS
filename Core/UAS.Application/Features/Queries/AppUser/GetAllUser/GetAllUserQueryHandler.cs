using MediatR;
using ServiceStack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Constans;
using UAS.Application.Dto.User;

namespace UAS.Application.Features.Queries.AppUser.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        readonly IUserService _userService;

        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllUserAsync();
            return new()
            {
                Users = users,
                TotalUsersCount = users.Data.Count(),
                Message= Constans.Message.GetAllUserSuccess,
                Success=true
            };
        }
    }
}

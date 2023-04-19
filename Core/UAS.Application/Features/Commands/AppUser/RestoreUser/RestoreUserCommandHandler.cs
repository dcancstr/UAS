using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Commands.AppUser.RestoreUser
{
    public class RestoreUserCommandHandler : IRequestHandler<RestoreUserCommandRequest, RestoreUserCommandResponse>
    {
        IUserService _userService;
        IMapper _mapper;
        public RestoreUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<RestoreUserCommandResponse> Handle(RestoreUserCommandRequest request, CancellationToken cancellationToken)
        {
            Dto.User.RestoreUser restoreUser = _mapper.Map<Dto.User.RestoreUser>(request);
            var result = await _userService.RestoreUserAsync(restoreUser);
            RestoreUserCommandResponse restoreUserCommandResponse = _mapper.Map<RestoreUserCommandResponse>(result);
            return restoreUserCommandResponse;
        }
    }
}

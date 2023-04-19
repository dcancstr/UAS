using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;

namespace UAS.Application.Features.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;
        public UpdateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var updateUser = _mapper.Map<Dto.User.UpdateUser>(request);
            var result = await _userService.UpdateUserAsync(updateUser);
            UpdateUserCommandResponse updateUserCommandResponse = _mapper.Map<UpdateUserCommandResponse>(result);
            return updateUserCommandResponse;
        }
    }

}
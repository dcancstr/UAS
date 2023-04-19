using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Features.Commands.AppUser.DeleteUser;

namespace UAS.Application.Features.Commands.AppUser.DeleteUserPermanent
{
    public class DeleteUserPermanentCommandHandler : IRequestHandler<DeleteUserPermanentCommandRequest, DeleteUserPermanentCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DeleteUserPermanentCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<DeleteUserPermanentCommandResponse> Handle(DeleteUserPermanentCommandRequest request, CancellationToken cancellationToken)
        {
            Dto.User.DeleteUser deleteUser = _mapper.Map<Dto.User.DeleteUser>(request);
            var result = await _userService.DeleteByIdPermanent(deleteUser);
            DeleteUserPermanentCommandResponse deleteUserCommandResponse = _mapper.Map<DeleteUserPermanentCommandResponse>(result);
            return deleteUserCommandResponse;
        }
    }
}

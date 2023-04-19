using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Common;
using UAS.Application.Dto.User;
using UAS.Application.Exceptions;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;

namespace UAS.Application.Features.Commands.AppUser.DeleteUser 
{ 
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            Dto.User.DeleteUser deleteUser = _mapper.Map<Dto.User.DeleteUser>(request);
            
            var result = await _userService.DeleteById(deleteUser);
            DeleteUserCommandResponse deleteUserCommandResponse = _mapper.Map<DeleteUserCommandResponse>(result);
            
            return deleteUserCommandResponse;
        }
    }
}

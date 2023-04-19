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

namespace UAS.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;
        readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            Dto.User.CreateUser createUser = _mapper.Map<Dto.User.CreateUser>(request);
            
            var result = await _userService.CreateAsync(createUser);
            CreateUserCommandResponse createUserCommandResponse = _mapper.Map<CreateUserCommandResponse>(result);
            
            return createUserCommandResponse;
        }
    }
}

using MediatR;
using UAS.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.AppUser.LogOutUser
{
    public class LogOutUserCommandHandler : IRequestHandler<LogOutUserCommandRequest, LogOutUserCommandResponse>
    {
        private readonly IAuthService _authService;
        public LogOutUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LogOutUserCommandResponse> Handle(LogOutUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _authService.LogOutAsync();
            return new LogOutUserCommandResponse();
        }
    }
}

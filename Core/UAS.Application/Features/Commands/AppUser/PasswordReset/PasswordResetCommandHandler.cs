using MediatR;
using UAS.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.AppUser.PasswordReset
{
    public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommandRequest, PasswordResetCommandResponse>
    {
        private readonly IUserService _userService;
        public PasswordResetCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<PasswordResetCommandResponse> Handle(PasswordResetCommandRequest request, CancellationToken cancellationToken)
        {
            return new PasswordResetCommandResponse { PasswordResetResponse = await _userService.ResetPasswordSendEmailLink(request.passwordReset) };
        }
    }
}

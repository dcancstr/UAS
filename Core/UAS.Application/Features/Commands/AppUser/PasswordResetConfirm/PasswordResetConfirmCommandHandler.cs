using MediatR;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.AppUser.PasswordResetConfirm
{
    public class PasswordResetConfirmCommandHandler : IRequestHandler<PasswordResetConfirmCommandRequest, PasswordResetConfirmCommandResponse>
    {
        private readonly IUserService _userService;

        public PasswordResetConfirmCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<PasswordResetConfirmCommandResponse> Handle(PasswordResetConfirmCommandRequest request, CancellationToken cancellationToken)
        {
            return new PasswordResetConfirmCommandResponse { PasswordResetConfirmResponse = await _userService.ResetPasswordConfirm(request.PasswordResetConfirm) };
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.AppUser.PasswordResetConfirm
{
    public class PasswordResetConfirmCommandRequest : IRequest<PasswordResetConfirmCommandResponse>
    {
        public UAS.Application.Dto.Auth.PasswordResetConfirm PasswordResetConfirm { get; set; }
    }    
}

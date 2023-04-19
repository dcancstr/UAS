using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.AppUser.LogOutUser
{
    public class LogOutUserCommandRequest : IRequest<LogOutUserCommandResponse>
    {
    }
}

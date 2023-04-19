using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.AppUser.RestoreUser
{
    public class RestoreUserCommandRequest : IRequest<RestoreUserCommandResponse>
    {
        public int Id { get; set; }
    }
}

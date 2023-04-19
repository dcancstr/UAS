using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.Role.AddMenuPanels
{
    public class AddMenuPanelsCommandRequest : IRequest<AddMenuPanelsCommandResponse>
    {
        public string model { get; set; }
    }
}

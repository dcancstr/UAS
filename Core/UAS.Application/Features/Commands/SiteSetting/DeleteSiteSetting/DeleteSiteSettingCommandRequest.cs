using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Commands.SiteSetting.RemoveSiteSetting
{
    public class DeleteSiteSettingCommandRequest : IRequest<DeleteSiteSettingCommandResponse>
    {
        public int Id { get; set; }
    }
}

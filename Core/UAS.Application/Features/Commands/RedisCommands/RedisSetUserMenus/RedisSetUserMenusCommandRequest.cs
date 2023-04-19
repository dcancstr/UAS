using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Domain.Entities;

namespace UAS.Application.Features.Commands.RedisCommands.RedisSetUserMenus
{
    public class RedisSetUserMenusCommandRequest : IRequest<RedisSetUserMenusCommandResponse>
    {
        public string UserName { get; set; }
        public List<MenuPanel> MenuPanels { get; set; }
        public List<MenuKategori> MenuKategories { get; set; }


    }
}

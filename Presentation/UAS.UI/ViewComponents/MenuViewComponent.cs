using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UAS.Application.Features.Commands.RedisCommands.RedisSetUserMenus;
using UAS.Application.Features.Queries.RedisQueries.RedisGetUserMenus;
using UAS.Application.Features.Queries.Role.GetMenupanelsWithUserName;

namespace UAS.UI.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MenuViewComponent(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cacheResult = await _mediator.Send(new RedisGetUserMenusQueryRequest { UserName = HttpContext.User.Identity.Name });
            if (cacheResult != null)
                return View(_mapper.Map<GetMenupanelsWithUserNameQueryResponse>(cacheResult));
            else
            {
                var dbResult = await _mediator.Send(new GetMenupanelsWithUserNameQueryRequest { UserName = HttpContext.User.Identity.Name });
                await _mediator.Send(new RedisSetUserMenusCommandRequest { UserName = HttpContext.User.Identity.Name, MenuKategories = dbResult.MenuKategories, MenuPanels = dbResult.MenuPanels });
                return View(dbResult);
            }
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.RedisCache;
using UAS.Application.Features.Commands.RedisCommands.RedisSetUserMenus;
using UAS.Application.Features.Queries.RedisQueries.RedisGetUserMenus;
using UAS.Application.Features.Queries.Role.GetMenupanelsWithUserName;

namespace UAS.UI.CustomAuthorize
{
    public class AllowedControllersHandler : AuthorizationHandler<AllowedControllersRequirement>
    {
        IMediator _mediator;
        public AllowedControllersHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AllowedControllersRequirement requirement)
        {
            var controller = (context.Resource as DefaultHttpContext)?.GetRouteValue("controller")?.ToString();
            var action = (context.Resource as DefaultHttpContext)?.GetRouteValue("action")?.ToString();

            if (requirement.AllowedControllers.Contains($"{controller}:{action}"))
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    var cacheResult = await _mediator.Send(new RedisGetUserMenusQueryRequest { UserName = context.User.Identity.Name });
                    List<Domain.Entities.MenuPanel> menuPanels = null;
                    if (cacheResult != null)
                    {
                        menuPanels = cacheResult.MenuPanels;
                    }
                    else
                    {
                        var dbResult = await _mediator.Send(new GetMenupanelsWithUserNameQueryRequest { UserName = context.User.Identity.Name });
                        await _mediator.Send(new RedisSetUserMenusCommandRequest { UserName = context.User.Identity.Name, MenuPanels = dbResult.MenuPanels, MenuKategories = dbResult.MenuKategories });
                        menuPanels = dbResult.MenuPanels;
                    }
                    if (menuPanels.Any(m => m.Controller == controller && m.Action == action))
                        context.Succeed(requirement);
                }
            }
            else if (context.User.Identity.IsAuthenticated)
            {
                context.Succeed(requirement);
            }


        }
    }
}

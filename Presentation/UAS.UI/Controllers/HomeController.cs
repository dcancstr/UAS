using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using UAS.Application.Abstractions.Services;
using UAS.Application.Abstractions.Services.RabbitMqServices;
using UAS.Application.Features.Queries.Role.GetMenupanelsWithUserName;

namespace UAS.UI.Controllers
{
    [Authorize]
    public class HomeController : CustomBaseController
    {
        private readonly IRedisCacheService _redisCache;
        public HomeController(IMediator mediator, IToastNotification toastNotification, IRedisCacheService redisCache, IRabbitMqExcelCreatePublisher rabbitMqExcelCreatePublisher) : base(mediator, toastNotification)
        {
            this._redisCache = redisCache;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<PartialViewResult> Menu()
        {
            //var response =   _mediator.Send(new GetMenupanelsWithUserNameQueryRequest { UserName = HttpContext.User.Identity.Name });
            return PartialView();
        }


        [HttpGet]
        public PartialViewResult Navbar()
        {
            return PartialView();
        }
    }
}

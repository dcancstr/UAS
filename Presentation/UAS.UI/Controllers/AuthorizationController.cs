using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using NToastNotify;

namespace UAS.UI.Controllers
{
    [Authorize]
    public class AuthorizationController : CustomBaseController
    {
        public AuthorizationController(IMediator mediator, IToastNotification toastNotification) : base(mediator, toastNotification)
        {
        }

        public IActionResult Roles()
        {
            return View();
        }
    }
}

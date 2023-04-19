using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using NToastNotify;
using UAS.UI.Helpers;

namespace UAS.UI.Controllers
{
    public class CustomBaseController : Controller
    {
        protected readonly IMediator _mediator;
        protected readonly IToastNotification _toastNotification;
        public CustomBaseController(IMediator mediator, IToastNotification toastNotification)
        {
            _mediator = mediator;
            _toastNotification = toastNotification;
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UAS.UI.ViewComponents
{
    public class NavBarViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        public NavBarViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

using Azure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using UAS.Application.Features.Commands.AppUser.UpdateUser;
using UAS.Application.Features.Commands.AppUser.UpdateUser.UpdateUserFromMyProfile;
using UAS.Application.Features.Queries.AppUser.GetUserByUserName;

namespace UAS.UI.Controllers
{
    [Authorize]
    public class ProfileController : CustomBaseController
    {


        public ProfileController(IMediator mediator, IToastNotification toastNotification) : base(mediator, toastNotification)
        {

        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            return View((await _mediator.Send(new GetUserByUserNameQueryRequest { GetUser = new Application.Dto.User.GetUser { UserName = HttpContext.User.Identity.Name } })).GetUserResponse);
        }
        [HttpPost]
        public async Task<IActionResult> ProfileGenelBilgilerUpdate(UpdateUserFromMyProfileCommandRequest updateUserCommandRequest, IFormFile file)
        {
            if (file != null)
            {
                updateUserCommandRequest.PersonelImage = file;

            }
           var response =  await _mediator.Send(updateUserCommandRequest);
            if (response.Success)
                _toastNotification.AddSuccessToastMessage("Kullanıcı başarıyla güncellendi", new ToastrOptions
                {
                    Title = "Başarılı işlem"
                });
            return RedirectToAction("MyProfile", "Profile", Json(new { success = response.Success }));
        }
        






    }
}

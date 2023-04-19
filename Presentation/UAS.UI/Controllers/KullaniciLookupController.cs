using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using UAS.Application.Dto.User;
using UAS.Application.Features.Commands.AppUser.CreateUser;
using UAS.Application.Features.Commands.AppUser.DeleteUser;
using UAS.Application.Features.Commands.AppUser.DeleteUserPermanent;
using UAS.Application.Features.Commands.AppUser.RestoreUser;
using UAS.Application.Features.Commands.AppUser.UpdateUser;
using UAS.Application.Features.Commands.AppUser.UpdateUser.UpdateUserFromMyProfile;
using UAS.Application.Features.Queries.AppUser.GetAllUser;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;

namespace UAS.UI.Controllers
{
    [Authorize(Policy = "AllowedControllerActions")]
    public class KullaniciLookupController : CustomBaseController
    {

        public KullaniciLookupController(IMediator mediator, IToastNotification toastNotification) : base(mediator, toastNotification)
        {
        }
        [HttpGet]
        public IActionResult KullaniciGuncelle()
        {
            return View();
        }
        [HttpGet]
        public IActionResult KullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciEkle(CreateUserCommandRequest createUserCommandRequest)
        {
            createUserCommandRequest.PasswordConfirm = createUserCommandRequest.Password;
            var response = await base._mediator.Send(createUserCommandRequest);
            if (response.Success)
                _toastNotification.AddSuccessToastMessage("Kullanıcı başarıyla eklendi", new ToastrOptions
                {
                    Title = "Başarılı işlem"
                });
            else
                _toastNotification.AddWarningToastMessage("Hata!\n" + response.Message, new ToastrOptions
                {
                    Title = "Başarısız işlem!"
                });
            return RedirectToAction("KullaniciEkle", "KullaniciLookup");
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciSil(DeleteUserCommandRequest deleteUserCommandRequest)
        {
            var response = await base._mediator.Send(deleteUserCommandRequest);
            if (response.Success)
            {
                _toastNotification.AddSuccessToastMessage("Kullanıcı başarıyla silindi.", new ToastrOptions()
                {
                    Title = "Başarılı İşlem"
                });
            }
            return Json(new { success = response.Success });
        }

        [HttpPost]
        public async Task<IActionResult> KullaniciDuzenle(UpdateUserCommandRequest updateUserCommandRequest)
        {
            var response = await base._mediator.Send(updateUserCommandRequest);
            if (response.Success)
            {
                _toastNotification.AddSuccessToastMessage("Kullanıcı başarıyla düzenlendi.", new ToastrOptions()
                {
                    Title = "Başarılı İşlem"
                });
            }
            return Json(new { success = response.Success });
        }
        [HttpGet]
        public IActionResult SilinmisKullanicilar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciKaliciSil(DeleteUserPermanentCommandRequest deleteUserPermanentCommandRequest)
        {
            var response = await base._mediator.Send(deleteUserPermanentCommandRequest);
            if (response.Success)
            {
                _toastNotification.AddSuccessToastMessage("Kullanıcı kalıcı olarak silindi.", new ToastrOptions()
                {
                    Title = "Başarılı İşlem"
                });
            }
            return Json(new { success = response.Success });

        }
        [HttpPost]
        public async Task<IActionResult> KullaniciAktiflestir(RestoreUserCommandRequest restoreUserCommandRequest)
        {
            var response = await base._mediator.Send(restoreUserCommandRequest);
            if (response.Success)
            {
                _toastNotification.AddSuccessToastMessage("Kullanıcı aktifleştirildi.", new ToastrOptions()
                {
                    Title = "Başarılı İşlem"
                });
            }
            return Json(new { success = response.Success });
        }

        [HttpGet]
        public IActionResult KullaniciRolAtamasi()
        {
            return View();
        }

    }
}

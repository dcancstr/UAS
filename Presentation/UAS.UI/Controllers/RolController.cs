using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NToastNotify;
using UAS.Application.Dto.Rol;
using UAS.Application.Features.Commands.Role.AddPersonelRol;
using UAS.Application.Features.Commands.Role.CreateRolAssingMenuPanel;
using UAS.Application.Features.Commands.Role.UpdateRolAssingPermission;
using UAS.Application.Features.Queries.Role.GetMenuPanels;
using UAS.Application.Features.Queries.Role.GetPersonelRolTips;
using UAS.Application.Features.Queries.Role.GetRoles;
using UAS.Application.Features.Queries.Role.UpdateRoleGetMenuPanels;
using UAS.Application.Features.Queries.Role.UpdateRoleOfMenuPanels;
using UAS.Application.Features.Queries.Role.UpdatePersonelRolGetUsers;
using UAS.Application.Utilities.Result.Common;
using Microsoft.AspNetCore.Authorization;

namespace UAS.UI.Controllers
{
    [Authorize(Policy = "AllowedControllerActions")]
    public class RolController : CustomBaseController
    {

        public RolController(IMediator mediator, IToastNotification toastNotification) : base(mediator, toastNotification)
        {
        }

        [HttpGet]
        public async Task<IActionResult> RolEkle()
        {
            return View((await _mediator.Send(new GetMenuPanelsQueryRequest())).CreateRoleAssignMenuListe);
        }

        [HttpPost]
        public async Task<IActionResult> RolEkle(CreateRoleAssignMenuListe createRoleAssignMenuListe)
        {
            var response = await _mediator.Send(new CreateRolAssingMenuPanelCommandRequest { CreateRoleAssignMenuListe = createRoleAssignMenuListe });
            if (response.IsSuccess)
                _toastNotification.AddSuccessToastMessage("rol başarıyla eklendi", new ToastrOptions
                {
                    Title = "Başarılı işlem"
                });
            else
                _toastNotification.AddWarningToastMessage("beklenmedik bir hata ile karşılaşıldı", new ToastrOptions
                {
                    Title = "Başarısız işlem!"
                });
            return RedirectToAction("RolEkle", "Rol");
        }

        [HttpGet]
        public async Task<IActionResult> RolGuncelle()
        {
            return View((await _mediator.Send(new UpdateRoleOfMenuPanelsQueryRequest())).UpdateRoleAssignMenuListe);
        }

        [HttpPost]
        public async Task<IActionResult> RolGuncelle(UpdateRoleAssignMenuListe updateRoleAssignMenuListe)
        {
            // hiçbir rol adı gelmediyse buraya girer
            if (string.IsNullOrEmpty(updateRoleAssignMenuListe.RoleName))
            {
                _toastNotification.AddInfoToastMessage("rol adı boş geçilemez", GetSettingToastr("uyarı!"));
                return View((await _mediator.Send(new UpdateRoleOfMenuPanelsQueryRequest())).UpdateRoleAssignMenuListe);
            }
            // rol adı geldiyse kullanıcının menülerini çekicekse buraya girer
            _toastNotification.AddInfoToastMessage("role bağlı işlemler gerçekleştirebilirsiniz", GetSettingToastr("sürdürülebilir"));
            return View((await _mediator.Send(new UpdateRoleGetMenuPanelsQueryRequest { UpdateRoleAssignMenuListe = updateRoleAssignMenuListe })).UpdateRoleAssignMenuListe);
        }

        [HttpPost]
        public async Task<IActionResult> RolGuncellePost(string data)
        {
            if (string.IsNullOrEmpty(data) || data.Length < 1)
            {
                _toastNotification.AddWarningToastMessage("bir rol seçiniz", GetSettingToastr("Uyarı!"));
                return RedirectToAction("RolGuncelle", "Rol");
            }
            var response = await _mediator.Send(new UpdateRolAssingPermissionCommandRequest { Data = data });
            if (response.UpdateRoleAssignMenuListe.IsSuccess)
            {
                _toastNotification.AddSuccessToastMessage("güncelleme işlemi başarılı", GetSettingToastr("başarılı işlem"));
            }
            else
            {
                _toastNotification.AddWarningToastMessage("beklenmedik bir hata oluştu", GetSettingToastr("hata!"));
            }
            return RedirectToAction("RolGuncelle", "Rol");
        }

        [NonAction]
        private ToastrOptions GetSettingToastr(string title)
        {
            return new ToastrOptions
            {
                Title = title,
                TapToDismiss = true,
                CloseOnHover = true,
                CloseButton = true,
                CloseEasing = true,
                HideDuration = 1,
                ShowDuration = 1,
                ProgressBar = true,
                PositionClass = ToastPositions.TopRight,
                NewestOnTop = true
            };
        }
        [HttpGet]
        public async Task<JsonResult> UpdatePersonelRolGetUsers()
        {
            var response = await _mediator.Send(new UpdatePersonelRolGetUsersQueryRequest());
            return Json(response.Data);
        }
        [HttpGet]
        public async Task<JsonResult> GetAllPersonelRolTipsJSON()
        {
            var response = await _mediator.Send(new GetPersonelRolTipsQueryRequest());
            return Json(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> AddPersonelRol(AddPersonelRolCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Json(new { Success = response.Success });
        }
    }
}

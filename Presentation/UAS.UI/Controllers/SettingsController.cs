using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using UAS.Application.Dto.SiteSettings;
using UAS.Application.Features.Commands.Role.AddMenuPanels;
using UAS.Application.Features.Commands.SiteSetting.UploadSiteSetting;
using UAS.Application.Features.Queries.Role.GetMenuKategoryList;
using UAS.Application.Features.Queries.SiteSetting.GetSiteSetting;

namespace UAS.UI.Controllers
{
    [Authorize(Policy = "AllowedControllerActions")]
    public class SettingsController : CustomBaseController
    {
        public SettingsController(IMediator mediator, IToastNotification toastNotification) : base(mediator, toastNotification)
        {
        }

        [HttpGet]
        public async Task<IActionResult> SiteSettings()
        {
            var response = await _mediator.Send(new GetSiteSettingQueryRequest());
            return View(response.SiteSettingsUpload);
        }

        [HttpPost]
        public async Task<IActionResult> SettingsUpload(SiteSettingsUpload siteSettingsUploadRequest)
        {
            await _mediator.Send(new UploadSiteSettingCommandRequest { SiteSettingsUpload = siteSettingsUploadRequest });
            if (!IsTwoImageRequest(siteSettingsUploadRequest))
                _toastNotification.AddWarningToastMessage("logo ve giriş resmi güncellemesi için ikisi aynı anda seçilmelidir", GetSettingToastr("Uyarı!"));
            _toastNotification.AddSuccessToastMessage("Güncelleme işlemi başarılı", GetSettingToastr("Başarılı işlem"));
            return RedirectToAction("SiteSettings", "Settings");
        }

        [HttpGet]
        public async Task<IActionResult> AddPageMenuPanel()
        {
            return View((_mediator.Send(new GetMenuKategoryListQueryRequest()).Result).GetMenuKategories);
        }

        [HttpPost]
        public async Task<JsonResult> AddPageMenuPanel(string model)
        {
            return Json(new { isSuccess = await _mediator.Send(new AddMenuPanelsCommandRequest { model = model }) });
        }

        [NonAction]
        bool IsTwoImageRequest(SiteSettingsUpload siteSettingsUploadRequest)
        {
            return siteSettingsUploadRequest.LayoutImage != null && siteSettingsUploadRequest.Logo != null;
        }

        [NonAction]
        ToastrOptions GetSettingToastr(string title)
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
    }
}

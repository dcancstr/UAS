using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Storage;
using UAS.Application.Repositories;
using UAS.Application.Dto.SiteSettings;
using Microsoft.Extensions.Options;
using UAS.Application.Helpers.Abstract;

namespace UAS.Application.Features.Commands.SiteSetting.UploadSiteSetting
{
    public class UploadSiteSettingCommandHandler : IRequestHandler<UploadSiteSettingCommandRequest, UploadSiteSettingCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly ISiteSettingReadRepository _siteSettingReadRepository;
        readonly ISiteSettingWriteRepository _siteSettingWriteRepository;
        readonly IConfiguration _configuration;


        private readonly SiteSettingsUpload _siteSettingsUpload;
        private readonly IWritableOptions<SiteSettingsUpload> _SiteSettingsUploadWriter;

        public UploadSiteSettingCommandHandler(IStorageService storageService, ISiteSettingReadRepository siteSettingReadRepository, ISiteSettingWriteRepository siteSettingWriteRepository, IConfiguration configuration, IOptionsSnapshot<SiteSettingsUpload> siteSettingsUpload, IWritableOptions<SiteSettingsUpload> siteSettingsUploadWriter)
        {
            _storageService = storageService;
            _siteSettingReadRepository = siteSettingReadRepository;
            _siteSettingWriteRepository = siteSettingWriteRepository;
            _configuration = configuration;

            _siteSettingsUpload = siteSettingsUpload.Value;
            _SiteSettingsUploadWriter = siteSettingsUploadWriter;
        }

        public async Task<UploadSiteSettingCommandResponse> Handle(UploadSiteSettingCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.SiteSettingsUpload.Logo != null && request.SiteSettingsUpload.LayoutImage != null)
            {
                await _storageService.DeleteAsync(_siteSettingsUpload.LogoUrl, _siteSettingsUpload.LayoutImageUrl, _siteSettingsUpload.SiteName);
                var datas = await _storageService.UploadAsync("logos", "layout-images", request.SiteSettingsUpload.Logo, request.SiteSettingsUpload.LayoutImage);
                _SiteSettingsUploadWriter.Update(x =>
                {
                    x.LayoutImageUrl = datas[0].layoutImageUrl;
                    x.LogoUrl = datas[0].logoUrl;
                    x.SmsGonderici = request.SiteSettingsUpload.SmsGonderici;
                    x.SmsApiUrl = request.SiteSettingsUpload.SmsApiUrl;
                    x.SmsApiKey = request.SiteSettingsUpload.SmsApiKey;
                    x.SmsApiId = request.SiteSettingsUpload.SmsApiId;
                    x.SiteName = request.SiteSettingsUpload.SiteName;
                    x.MailAdresi = request.SiteSettingsUpload.MailAdresi;
                    x.MailSifresi = request.SiteSettingsUpload.MailSifresi;
                    x.MailSunucuAdresi = request.SiteSettingsUpload.MailSunucuAdresi;
                    x.MailSunucuPortu = request.SiteSettingsUpload.MailSunucuPortu;
                });
            }
            else
            {
                _SiteSettingsUploadWriter.Update(x =>
                {
                    x.LayoutImageUrl = _siteSettingsUpload.LayoutImageUrl;
                    x.LogoUrl = _siteSettingsUpload.LogoUrl;
                    x.SmsGonderici = request.SiteSettingsUpload.SmsGonderici;
                    x.SmsApiUrl = request.SiteSettingsUpload.SmsApiUrl;
                    x.SmsApiKey = request.SiteSettingsUpload.SmsApiKey;
                    x.SmsApiId = request.SiteSettingsUpload.SmsApiId;
                    x.SiteName = request.SiteSettingsUpload.SiteName;
                    x.MailAdresi = request.SiteSettingsUpload.MailAdresi;
                    x.MailSifresi = request.SiteSettingsUpload.MailSifresi;
                    x.MailSunucuAdresi = request.SiteSettingsUpload.MailSunucuAdresi;
                    x.MailSunucuPortu = request.SiteSettingsUpload.MailSunucuPortu;
                });
            }

            return new() { SiteSettingsUpload = _siteSettingsUpload };
        }
    }
}

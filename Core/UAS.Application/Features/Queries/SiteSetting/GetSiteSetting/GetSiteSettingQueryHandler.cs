using MediatR;
using Microsoft.Extensions.Options;
using UAS.Application.Dto.SiteSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.SiteSetting.GetSiteSetting
{
    public class GetSiteSettingQueryHandler : IRequestHandler<GetSiteSettingQueryRequest, GetSiteSettingQueryResponse>
    {
        private readonly SiteSettingsUpload _siteSettingsUpload;
        public GetSiteSettingQueryHandler(IOptionsSnapshot<SiteSettingsUpload> siteSettingsUpload)
        {
            _siteSettingsUpload = siteSettingsUpload.Value;
        }
        public async Task<GetSiteSettingQueryResponse> Handle(GetSiteSettingQueryRequest request, CancellationToken cancellationToken)
        {
            return new GetSiteSettingQueryResponse
            {
                SiteSettingsUpload = _siteSettingsUpload
            };
        }
    }
}

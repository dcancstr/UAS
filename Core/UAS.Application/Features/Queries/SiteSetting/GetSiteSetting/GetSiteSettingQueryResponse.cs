using Microsoft.AspNetCore.Http;
using UAS.Application.Dto.SiteSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Features.Queries.SiteSetting.GetSiteSetting
{
    public class GetSiteSettingQueryResponse
    {
        public SiteSettingsUpload SiteSettingsUpload { get; set; }
    }
}

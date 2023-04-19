using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.SiteSettings
{
    public class SiteSettingsUpload
    {
        public string SiteName { get; set; }
        public IFormFile Logo { get; set; }
        public string LogoUrl { get; set; }
        public IFormFile LayoutImage { get; set; }
        public string LayoutImageUrl { get; set; }
        public string SmsApiUrl { get; set; }
        public string SmsApiId { get; set; }
        public string SmsApiKey { get; set; }
        public string SmsGonderici { get; set; }
        public string MailSunucuAdresi { get; set; }
        public string MailSunucuPortu { get; set; }
        public string MailAdresi { get; set; }
        public string MailSifresi { get; set; }
    }
}

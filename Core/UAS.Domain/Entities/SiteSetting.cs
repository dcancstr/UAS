using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Domain.Entities
{
    public class SiteSetting : BaseEntity<int>
    {
        public string SiteName { get; set; }
        public string LogoUrl { get; set; }
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

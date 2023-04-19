using Microsoft.Extensions.Options;
using UAS.Application.Dto.SiteSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Email;

namespace UAS.Infrastructure.Services.Email
{
    public class MailService : IMailService
    {
        private readonly SiteSettingsUpload _siteSettingsUpload;
        public MailService(IOptionsSnapshot<SiteSettingsUpload> optionsSnapshot)
        {
            _siteSettingsUpload = optionsSnapshot.Value;
        }

        public bool ResetPasswordConfirmedEmail(string url, string email)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_siteSettingsUpload.MailAdresi);
            message.To.Add(new MailAddress(email));
            message.Subject = $"{_siteSettingsUpload.SiteName} :: Şifre sıfırlama";
            message.Body = "<h1>Şifrenizi sıfırlamak için aşağıdaki linke tıklayınız</h1><hr/>";
            message.Body += $"<a href='{url}'> E-posta doğrulama linki </a>";
            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = _siteSettingsUpload.MailSunucuAdresi;
            smtp.Port = Convert.ToInt32(_siteSettingsUpload.MailSunucuPortu);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(_siteSettingsUpload.MailAdresi, _siteSettingsUpload.MailSifresi);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

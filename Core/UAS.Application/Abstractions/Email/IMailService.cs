using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Abstractions.Email
{
    public interface IMailService
    {
        bool ResetPasswordConfirmedEmail(string url, string email);
    }
}

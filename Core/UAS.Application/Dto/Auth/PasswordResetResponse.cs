using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Auth
{
    public class PasswordResetResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}

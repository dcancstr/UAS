using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UAS.Application.Dto.Common;
using UAS.Application.Dto.Token;

namespace UAS.Application.Dto.Auth
{
    public class LoginUserResponse : BaseResponse
    {
        public AccessToken? Token { get; set; }
    }
}

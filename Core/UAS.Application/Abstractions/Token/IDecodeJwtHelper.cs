﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Abstractions.Token
{
    public interface IDecodeJwtHelper
    {
        bool DecodeJwt(string jwt);
    }
}

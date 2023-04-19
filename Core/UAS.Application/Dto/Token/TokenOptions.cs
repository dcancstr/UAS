﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Dto.Token
{
    public class TokenOptions
    {
        public string? Audience { get; set; }
        public string? Issuer { get; set; }
        public int? ExpirationTime { get; set; }
        public string? SecurityKey { get; set; }
        public int RefreshTokenExpirationTime { get; set; }
    }
}

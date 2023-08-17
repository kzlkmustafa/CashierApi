﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Security.jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; } 
        public int AccessTokenExpiration { get; set; } 
        public string SecurityKey { get; set; } 
    }
}

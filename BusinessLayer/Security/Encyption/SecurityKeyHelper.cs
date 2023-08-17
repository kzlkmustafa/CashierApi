using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Security.Encyption
{
    public class SecurityKeyHelper
    {
        public static async Task<SecurityKey> CreateSecurityKey(string securityKey)
        {
            await Task.Delay(10);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            return key;
        }
    }
}

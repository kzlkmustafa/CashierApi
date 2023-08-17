using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Security.Encyption
{
    public class SigningCredentialsHelper
    {
        public static async Task<SigningCredentials> CreateSigninCreadenitals(SecurityKey securityKey)
        {
            await Task.Delay(10);
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            return credential;
        }
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Security.jwt
{
    public interface ITokenHelper
    {
        Task<AccessToken> CreateToken(AppUser appuser,IEnumerable<OperationClaim> operationclaims);
    }
}

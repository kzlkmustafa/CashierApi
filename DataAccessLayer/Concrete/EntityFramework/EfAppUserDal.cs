using CoreLayer.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfAppUserDal : EfEntityRepositoryBase<AppUser, CashierContext>, IAppUserDal
    {
        public async Task<IEnumerable<OperationClaim>> GetClaimsAsync(AppUser user)
        {
            using(CashierContext context = new CashierContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join useroperationclaim in context.UserOperationClaims
                             on operationClaim.OperationClaimId equals useroperationclaim.OperationClaimId
                             where useroperationclaim.AppUserId == user.AppUserId
                             select new OperationClaim { OperationClaimId = operationClaim.OperationClaimId, Name = operationClaim.Name };
                IEnumerable<OperationClaim> claims = await result.ToListAsync();
                return claims;

            }
        }
    }
}

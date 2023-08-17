using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    internal interface IAppUserService : IGenericService<AppUserDto>
    {
        Task<IDataResult<IEnumerable<OperationClaim>>> GetClaims(int userid);
        Task<IDataResult<AppUserDto>> GetByMail(string mail);
    }
}

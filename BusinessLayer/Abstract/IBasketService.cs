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
    public interface IBasketService : IGenericService<BasketDto>
    {

        Task<IResult> Add(BasketAddDto basketaddto);
        Task<IDataResult<IEnumerable<BasketDto>>> GetListByCashier(int cashierId);
    }
}
    
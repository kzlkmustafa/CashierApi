using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBasketDetailService : IGenericService<BasketDetailDto>
    {
        Task<IResult> Add(BasketDetailDto basketdetaildto);
        Task<IDataResult<IEnumerable<BasketDetailDto>>> GetListbyBasketId(int basketId);
        Task<IDataResult<IEnumerable<BasketDetailDto>>> GetListbyProductId(int productId);
    }
}

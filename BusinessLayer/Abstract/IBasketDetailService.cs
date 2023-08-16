using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBasketDetailService : IGenericService<BasketDetail>
    {
        Task<IDataResult<IEnumerable<BasketDetail>>> GetListbyBasketId(int basketId);
        Task<IDataResult<IEnumerable<BasketDetail>>> GetListbyProductId(int productId);
    }
}

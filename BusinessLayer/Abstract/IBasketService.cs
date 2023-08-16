using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        Task<IDataResult<IEnumerable<Basket>>> GetListByCashier(int cashierId);
    }
}
    
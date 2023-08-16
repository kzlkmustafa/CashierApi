using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {

        Task<IResult> Add(Product product);
        Task<IDataResult<IEnumerable<Product>>> GetListByKdvId(int kdvId);
        Task<IDataResult<IEnumerable<Product>>> GetListByCategoryId(int categoryId);
    }
}

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
    public interface IProductService : IGenericService<ProductDto>
    {

        Task<IResult> Add(ProductAddDto productadddto);
        Task<IDataResult<IEnumerable<ProductDto>>> GetListByKdvId(int kdvId);
        Task<IDataResult<IEnumerable<ProductDto>>> GetListByCategoryId(int categoryId);
    }
}

using CoreLayer.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        Task<IDataResult<T>> GetById(int id);
        Task<IDataResult<IEnumerable<T>>> GetList();
        Task<IResult> Add(T entity);
        Task<IResult> Update(T entity);
        Task<IResult> Delete(int id);
    }
}

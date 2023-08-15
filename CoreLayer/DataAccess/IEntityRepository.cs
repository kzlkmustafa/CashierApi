using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class , IEntity, new()
    {
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);

    }
}

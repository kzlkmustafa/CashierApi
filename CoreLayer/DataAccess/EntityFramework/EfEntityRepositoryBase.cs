using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreLayer.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<Tentity, TContext> : IEntityRepository<Tentity>
        where Tentity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task AddAsync(Tentity entity)
        {
            using(var context = new TContext())
            {
                await context.Set<Tentity>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new TContext())
            {

                var entity = await context.Set<Tentity>().FindAsync(id);
                if(entity != null)
                {
                    context.Set<Tentity>().Remove(entity);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                IQueryable<Tentity> query = context.Set<Tentity>();

                return filter == null
                    ? await query.ToListAsync()
                    : await query.Where(filter).ToListAsync();
            }
        }

        public async Task<Tentity> GetByIdAsync(Expression<Func<Tentity, bool>> filter)
        {
            using(var context = new TContext())
            {
                return await context.Set<Tentity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task UpdateAsync(Tentity entity)
        {
            using (var context = new TContext())
            {
                context.Set<Tentity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}

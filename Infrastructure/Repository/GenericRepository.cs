using Application.InterfaceRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> _dbSet;
        public GenericRepository(AppDbContext appDbContext)
        {
           _dbSet = appDbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async  Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes
         .Aggregate(_dbSet.AsQueryable(),
             (entity, property) => entity.Include(property))
         .Where(expression).Where(x => x.IsDelete == false).ToListAsync();
        }

        public async  Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes
           .Aggregate(_dbSet.AsQueryable(),
               (entity, property) => entity.Include(property))
           .Where(x => x.IsDelete == false)
           .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await this.GetByIdAsync(id, Array.Empty<Expression<Func<TEntity, object>>>());
        }

        public async  Task<TEntity?> GetByIdAsync(Guid id, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes
            .Aggregate(_dbSet.AsQueryable(),
                (entity, property) => entity.Include(property))
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id) && x.IsDelete == false);
        }

        public void SoftRemove(TEntity entity)
        {
            entity.IsDelete = true;
            _dbSet.Update(entity);
        }

        public void SoftRemoveRange(List<TEntity> entities)
        {
           foreach(TEntity entity in entities)
            {
                entity.IsDelete = false;
            }
            _dbSet.UpdateRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}

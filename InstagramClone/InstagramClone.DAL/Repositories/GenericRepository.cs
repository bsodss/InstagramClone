using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.DAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity: BaseEntity
    {
        private readonly InstagramCloneDbContext _db;

        public GenericRepository(InstagramCloneDbContext db)
        {
            _db = db;
        }

        public IQueryable<TEntity> FindAll()
        {
            return _db.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _db.Set<TEntity>().FirstOrDefaultAsync(f => f.Id ==Guid.Parse(id));
        }

        public async Task AddAsync(TEntity entity)
        {
            await _db.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var entity = await _db.Set<TEntity>().FirstAsync(f=> f.Id==Guid.Parse(id));
            _db.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> FindAllWithDetails(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = _db.Set<TEntity>();
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        public TEntity FindByIdWithDetails(string id)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InstagramClone.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> FindAll();
        Task<TEntity> GetByIdAsync(string id);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task DeleteByIdAsync(string id);
        IQueryable<TEntity> FindAllWithDetails(params Expression<Func<TEntity, object>>[] includes);
        TEntity FindByIdWithDetails(string id);
    }

    
}

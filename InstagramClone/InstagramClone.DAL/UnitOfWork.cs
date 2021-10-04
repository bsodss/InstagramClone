using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;
using InstagramClone.DAL.Repositories;

namespace InstagramClone.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly InstagramCloneDbContext _db;

        public UnitOfWork(InstagramCloneDbContext db)
        {
            _db = db;

        }

        
        public IRepository<T> GetGenericRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_db);
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}

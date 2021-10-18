using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;
using InstagramClone.DAL.Repositories;

namespace InstagramClone.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InstagramCloneDbContext _db;
        private  IDictionary<Type, object> _repositoriesFactory;
        public UnitOfWork(InstagramCloneDbContext db)
        {
            _db = db;

        }

        public IRepository<T> GetGenericRepository<T>() where T : BaseEntity
        {
            _repositoriesFactory ??= new Dictionary<Type, object>();

            var type = typeof(T);

            if (!_repositoriesFactory.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _db);
                _repositoriesFactory.Add(type, repositoryInstance);
            }
            return (GenericRepository<T>)_repositoriesFactory[type];
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}

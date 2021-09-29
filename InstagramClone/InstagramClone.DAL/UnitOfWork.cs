using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Interfaces;
using InstagramClone.DAL.Repositories;

namespace InstagramClone.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly InstagramCloneDbContext _db;

        private IUserRepository _userRepository;

        public IUserRepository UserRepository {
            get
            {
                return _userRepository ??= new UserRepository(_db);
            }
        }

        public UnitOfWork(InstagramCloneDbContext db)
        {
            _db = db;
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }
    }
}

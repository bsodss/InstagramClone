using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;

namespace InstagramClone.DAL.Repositories
{
    public class UserRepository:IUserRepository
    {

        private readonly InstagramCloneDbContext _db;

        public UserRepository(InstagramCloneDbContext db)
        {
            _db = db;
        }

        public IQueryable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

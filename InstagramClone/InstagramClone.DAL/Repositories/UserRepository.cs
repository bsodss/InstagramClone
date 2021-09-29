using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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
            return _db.Users;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _db.Users.FirstOrDefaultAsync(i => i.Id == Guid.Parse(id));
        }

        public async Task AddAsync(User entity)
        {
            await _db.Users.AddAsync(entity);
        }

        public void Update(User entity)
        { 
            _db.Users.Update(entity);
        }

        public void Delete(User entity)
        {
            _db.Users.Remove(entity);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var user = await _db.Users.FirstAsync(i => i.Id == Guid.Parse(id));
            _db.Users.Remove(user);
        }

        public IQueryable<User> FindAllWithDetails()
        {
            return _db.Users.Include(i => i.UserProfile)
                .Include(i => i.Posts)
                .Include(i => i.Subscriptions)
                .Include(i => i.Subscribers);
        }

        public User GetByIdWithDetails(string id)
        {
            return FindAllWithDetails().FirstOrDefault(i => i.Id == Guid.Parse(id));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;

namespace InstagramClone.DAL.Repositories
{
    public class PostRepository :IPostRepository
    {
        private readonly InstagramCloneDbContext _db;

        public PostRepository(InstagramCloneDbContext db)
        {
            _db = db;
        }
        public IQueryable<Post> FindAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Post> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(Post entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Post entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}

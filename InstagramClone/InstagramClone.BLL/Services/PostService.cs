using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InstagramClone.BLL.Interfaces;
using InstagramClone.BLL.Models;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;

namespace InstagramClone.BLL.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PostService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        //private IQueryable<Post> GetPostsWithDetails()=> _uow.GetGenericRepository<Post>().FindAllWithDetails()

        public IEnumerable<PostModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PostModel> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(PostModel model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(PostModel model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(string modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostModel>> GetUserPosts(string userId)
        {
            throw new NotImplementedException();
        }
    }
}

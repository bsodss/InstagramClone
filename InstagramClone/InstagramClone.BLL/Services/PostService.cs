using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using InstagramClone.BLL.Interfaces;
using InstagramClone.BLL.Models;
using InstagramClone.BLL.Validation;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

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


        private IQueryable<Post> GetPostsWithDetails() => _uow.GetGenericRepository<Post>().FindAllWithDetails(
            user => user.User,
            comment => comment.Comments);

        public IEnumerable<PostModel> GetAll()
        {
            return _mapper.Map<IEnumerable<PostModel>>(GetPostsWithDetails().AsEnumerable());
        }

        public async Task<PostModel> GetByIdAsync(string id)
        {
            if (id == null)
            {
                throw new InstagramCloneException("Parameter id can not be null");
            }
            var post = await GetPostsWithDetails().FirstOrDefaultAsync(f => f.Id == Guid.Parse(id));
            if (post == null)
            {
                throw new InstagramCloneException("Post with such id does not exist!");
            }

            return _mapper.Map<PostModel>(post);
        }

        public async Task AddAsync(PostModel model)
        {
            
        }

        public async Task UpdateAsync(PostModel model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(string modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostModel>> GetUserPostsAsync(string userId)
        {
            if (userId == null)
            {
                throw new InstagramCloneException("Parameter id can not be null");
            }

            IEnumerable<Post> posts = null;
            await Task.Run(() => { posts = GetPostsWithDetails().Where(f => f.UserId == Guid.Parse(userId)); });

            if (posts == null)
            {
                throw new InstagramCloneException("Posts with such userId does not exist!");
            }

            return _mapper.Map<IEnumerable<PostModel>>(posts);
        }
    }
}

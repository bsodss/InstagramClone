using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public IEnumerable<UserModel> GetAll()
        {
            return _mapper.Map<IEnumerable<UserModel>>(GetUsersWithDetails().AsAsyncEnumerable());
        }

        private IQueryable<User> GetUsersWithDetails() => _uow.GetGenericRepository<User>().FindAllWithDetails(
            s1 => s1.Subscribers,
            s2 => s2.Subscriptions, p => p.Posts, up => up.UserProfile);


        public async Task<UserModel> GetByIdAsync(string id)
        {
            if (id == null)
            {
                throw new InstagramCloneException("Parameter id can not be null!");
            }

            var user = await GetUsersWithDetails().FirstOrDefaultAsync(f => f.Id == Guid.Parse(id));

            if (user == null)
            {
                throw new InstagramCloneException("User with such id does not exist!");
            }

            return _mapper.Map<UserModel>(user);
        }

        public async Task AddAsync(UserModel model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(UserModel model)
        {

            await Task.Run(()=> _uow.GetGenericRepository<User>().Update(_mapper.Map<User>(model)));
        }

        public async Task DeleteByIdAsync(string modelId)
        {
            throw new NotImplementedException();
        }

    
        public async Task<UserModel> FindByUserNameAsync(string username)
        {
            if (username == null)
            {
                throw new InstagramCloneException("Parameter username can not be null!");
            }
            var user = await GetUsersWithDetails().FirstOrDefaultAsync(f => f.UserProfile.UserName == username);
            if (user == null)
            {
                throw new InstagramCloneException("User with such username does not exist!");
            }

            return _mapper.Map<UserModel>(user);
        }
    }
}

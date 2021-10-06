using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.BLL.Models;

namespace InstagramClone.BLL.Interfaces
{
    public interface IUserService : IBaseService<UserModel>
    {
        public Task<UserModel> FindByUserNameAsync(string username);
    }
}

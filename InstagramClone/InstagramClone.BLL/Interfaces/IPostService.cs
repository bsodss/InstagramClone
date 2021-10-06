using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.BLL.Models;

namespace InstagramClone.BLL.Interfaces
{
    public interface IPostService: IBaseService<PostModel>
    {
        Task<IEnumerable<PostModel>> GetUserPosts(string userId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.BLL.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<string> GetAllRoles();

        Task<string> AddRole(string name);

        Task<IEnumerable<string>> GetAllUserRoles(string userId);

        Task EditAccountRoles(string accountId, List<string> roles);


    }
}

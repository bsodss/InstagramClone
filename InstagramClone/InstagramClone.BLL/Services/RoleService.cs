using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.BLL.Interfaces;
using InstagramClone.BLL.Validation;
using InstagramClone.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InstagramClone.BLL.Services
{
    public class RoleService: IRoleService
    {

        private readonly UserManager<InstagramUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(UserManager<InstagramUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<string> GetAllRoles()
        {
            return _roleManager.Roles.Select(s => s.Name);
        }

        public async Task<string> AddRole(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InstagramCloneException("Name for role is not valid");

            var role = new IdentityRole(name);
            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
                throw new InstagramCloneException("Role with such name is already exist");
            return role.Name;
        }

        public async Task<IEnumerable<string>> GetAllUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new InstagramCloneException("There no account with that Id");

            var accountRoles = await _userManager.GetRolesAsync(user);
            if (accountRoles == null)
                throw new InstagramCloneException("That account doesn't have any roles");

            return accountRoles;

        }

        public async Task EditAccountRoles(string accountId, List<string> roles)
        {
            throw new NotImplementedException();
        }
    }
}

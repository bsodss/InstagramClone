using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InstagramClone.BLL.Models.Authorize;
using InstagramClone.BLL.Models.Response;
using Microsoft.AspNetCore.Identity;

namespace InstagramClone.BLL.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<RegisterResponseModel> RegisterUserAsync(RegisterModel model);
        public Task<LoginResponseModel> LogInUserAsync(LoginModel model);

    }
}

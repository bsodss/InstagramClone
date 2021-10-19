using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InstagramClone.BLL.Interfaces;
using InstagramClone.BLL.JwtFeatures;
using InstagramClone.BLL.Models.Authorize;
using InstagramClone.BLL.Models.Response;
using InstagramClone.BLL.Validation;
using InstagramClone.DAL.Entities;
using InstagramClone.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace InstagramClone.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUnitOfWork _uow;
        private readonly JwtHandler _jwtHandler;
        private readonly UserManager<InstagramUser> _userManager;
        public AuthorizationService(IUnitOfWork uow, JwtHandler jwtHandler, UserManager<InstagramUser> userManager)
        {
            _uow = uow;
            _jwtHandler = jwtHandler;
            _userManager = userManager;
        }
        public async Task<RegisterResponseModel> RegisterUserAsync(RegisterModel model)
        {
            if (model == null)
            {
                throw new InstagramCloneException("You did not provide correct data", nameof(RegisterUserAsync));
            }
            if (model.Password != model.ConfirmPassword)
            {
                throw new InstagramCloneException("Passwords are not equals", nameof(RegisterUserAsync));
            }

            var user = new InstagramUser()
            {
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);


        }

        public async Task<LoginResponseModel> LogInUserAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}

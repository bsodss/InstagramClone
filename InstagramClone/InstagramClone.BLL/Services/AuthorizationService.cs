using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
            if (result.Succeeded)
            {
                await _uow.GetGenericRepository<Account>().AddAsync(new Account()
                {
                    UserAccount = user,
                    UserProfile = new UserProfile()
                    {
                        IsPrivate = false,
                        ProfileDescription = "",
                        UserName = model.UserName
                    }
                });
                await _userManager.AddToRoleAsync(user, "User");
                await _uow.SaveAsync();
            }

            return new RegisterResponseModel()
                { IsSuccessful = result.Succeeded, Errors = result.Errors.Select(e => e.Description) }; 
        }

        public async Task<LoginResponseModel> LogInUserAsync(LoginModel model)
        {
            if (model == null)
            {
                throw new InstagramCloneException("You did not provide correct data", nameof(RegisterUserAsync));
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return new LoginResponseModel() { IsAuthSuccessful = false, ErrorMessage = "Invalid Authentication" };
            }
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = await _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new LoginResponseModel()
            {
                IsAuthSuccessful = true,
                Token = token
            };
        }
    }
}

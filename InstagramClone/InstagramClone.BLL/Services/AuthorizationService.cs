using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InstagramClone.BLL.Interfaces;
using InstagramClone.BLL.Models.Authorize;
using InstagramClone.BLL.Models.Response;
using InstagramClone.DAL.Interfaces;

namespace InstagramClone.BLL.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private IUnitOfWork _uow;
        private IMapper _mapper;

        public AuthorizationService(IUnitOfWork uow, IMapper _mapper)
        {
            _uow = uow;
        }
        public async Task<RegisterResponseModel> RegisterUserAsync(RegisterModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponseModel> LogInUserAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}

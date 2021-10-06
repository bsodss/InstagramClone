using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using InstagramClone.BLL.Interfaces;
using InstagramClone.DAL.Interfaces;

namespace InstagramClone.BLL.Services
{
    public class UserProfileService /*: IUserProfileService*/
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserProfileService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
    }
}

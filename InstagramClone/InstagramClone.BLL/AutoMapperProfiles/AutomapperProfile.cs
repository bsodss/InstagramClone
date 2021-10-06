using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using InstagramClone.BLL.Models;
using InstagramClone.DAL.Entities;

namespace InstagramClone.BLL.AutoMapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           //UserModel map
           CreateMap<User, UserModel>()
               .ForMember(m => m.UserModelSubscribersIds,
                   opt => opt.MapFrom(req => req.Subscribers.Select(s => s.Id)))
               .ForMember(m=>m.UserModelSubscriptionsIds,
                   opt=>opt.MapFrom(req=>req.Subscriptions.Select(s=>s.Id))).ReverseMap();
        }

    }
}

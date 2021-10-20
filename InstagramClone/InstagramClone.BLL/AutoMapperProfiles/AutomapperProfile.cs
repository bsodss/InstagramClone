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
           //UserModelЫ
           CreateMap<Account, UserModel>()
               .ForMember(m=> m.UserId,
                   opt=>opt.MapFrom(req=>req.Id.ToString()))
               .ForMember(m => m.UserModelSubscribersIds,
                   opt => opt.MapFrom(req => req.Subscribers.Select(s => s.Id)))
               .ForMember(m=>m.UserModelSubscriptionsIds,
                   opt=>opt.MapFrom(req=>req.Subscriptions.Select(s=>s.Id))).ReverseMap();

           //PostModel
           CreateMap<Post, PostModel>()
               .ForMember(m => m.CommentsIds,
                   opt => opt.MapFrom(req => req.Comments.Select(s => s.Id))).ReverseMap();

           //CommentModel
           CreateMap<Comment, CommentModel>().ReverseMap();
        }

    }
}

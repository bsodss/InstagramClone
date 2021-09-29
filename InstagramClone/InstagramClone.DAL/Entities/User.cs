using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramClone.DAL.Entities
{
    public class User : BaseEntity
    {
        public UserProfile UserProfile { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserRelations> Subscriptions { get; set; }
        public ICollection<UserRelations> Subscribers { get; set; }
    }
}

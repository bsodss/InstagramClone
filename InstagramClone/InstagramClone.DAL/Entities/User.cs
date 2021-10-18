using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InstagramClone.DAL.Entities
{
    public class User : BaseEntity
    {
        [Key]
        [ForeignKey("UserAccount")]
        public new Guid Id { get; set; }
        public Account UserAccount { get; set; }

        public UserProfile UserProfile { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserRelations> Subscriptions { get; set; }
        public ICollection<UserRelations> Subscribers { get; set; }
    }
}

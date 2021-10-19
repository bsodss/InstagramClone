using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace InstagramClone.DAL.Entities
{
    public class Account : BaseEntity
    {
        [Key]
        [ForeignKey("UserAccount")]
        public new Guid Id { get; set; }
        public InstagramUser UserAccount { get; set; }

        public UserProfile UserProfile { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserRelation> Subscriptions { get; set; }
        public ICollection<UserRelation> Subscribers { get; set; }
    }
}

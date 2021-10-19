using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstagramClone.DAL.Entities
{
    public class UserRelation : BaseEntity
    {
        public Guid RequestedById { get; set; }
        public Account RequestedBy { get; set; }

        public Account RequestedTo { get; set; }
        public Guid RequestedToId { get; set; }

        public Status Status { get; set; }
    }

    public enum Status
    {
        Accepted = 0,
        InFriendship = 1,
        Decline = 2
    }
}

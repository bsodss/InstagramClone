using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstagramClone.DAL.Entities
{
    public class Comment : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string CommentText { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}

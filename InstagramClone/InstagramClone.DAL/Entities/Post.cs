using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstagramClone.DAL.Entities
{
    public class Post : BaseEntity
    {
        [Required]
        public byte[] Photo { get; set; }
        public string PostText { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

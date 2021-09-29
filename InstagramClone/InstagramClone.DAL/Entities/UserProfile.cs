using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstagramClone.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string UserName { get; set; }
        public string ProfileDescription { get; set; }
        public bool IsPrivate { get; set; }
    }
}

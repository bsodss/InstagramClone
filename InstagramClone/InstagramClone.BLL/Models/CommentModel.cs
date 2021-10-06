using System;
using System.Collections.Generic;
using System.Text;
using InstagramClone.DAL.Entities;

namespace InstagramClone.BLL.Models
{
    public class CommentModel
    {
        public Guid UserId { get; set; }
        public string CommentText { get; set; }
        public Guid PostId { get; set; }
    }
}

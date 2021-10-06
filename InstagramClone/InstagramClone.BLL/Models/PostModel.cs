using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramClone.BLL.Models
{
    public class PostModel
    {
        public Guid Id { get; set; }
        public byte[] Photo { get; set; }
        public string PostText { get; set; }

        public DateTime DatePosted { get; set; }

        public ICollection<Guid> CommentsIds { get; set; }
    }
}

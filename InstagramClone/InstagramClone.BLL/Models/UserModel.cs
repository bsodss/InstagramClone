using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramClone.BLL.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string ProfileDescription { get; set; }
        public bool IsPrivate { get; set; }

        public ICollection<Guid> UserModelSubscribersIds { get; set; }
        public ICollection<Guid> UserModelSubscriptionsIds { get; set; }
        private ICollection<Guid> UserModelPostsIds { get; set; }
    }
}

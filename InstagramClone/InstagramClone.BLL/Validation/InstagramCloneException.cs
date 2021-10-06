using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramClone.BLL.Validation
{
    public class InstagramCloneException : Exception
    {
        public string Property { get; set; }
        public InstagramCloneException(string message) : base(message)
        {

        }

        public InstagramCloneException(string message, string property) : base(message)
        {
            Property = property;
        }

    }
}

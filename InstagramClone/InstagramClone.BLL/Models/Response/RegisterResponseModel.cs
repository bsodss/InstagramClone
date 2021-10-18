using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramClone.BLL.Models.Response
{
    public class RegisterResponseModel
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}

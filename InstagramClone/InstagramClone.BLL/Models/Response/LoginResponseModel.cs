using System;
using System.Collections.Generic;
using System.Text;

namespace InstagramClone.BLL.Models.Response
{
    public class LoginResponseModel
    {
        public bool IsAuthSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }

    }
}

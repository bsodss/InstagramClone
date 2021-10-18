using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InstagramClone.BLL.Models.Authorize
{
    public class RegisterModel
    {
        public string Id { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords are not equals")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}

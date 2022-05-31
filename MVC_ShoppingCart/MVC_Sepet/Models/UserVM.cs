using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Sepet.Models
{
    public class UserVM
    {
        [Required(ErrorMessage ="Invalid Username!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Invalid Password!")]
        public string Password { get; set; }
    }
}
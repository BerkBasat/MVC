using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_NORTHWIND.Models
{
    public class UserVM
    {
        [Required(ErrorMessage ="Username cannot be empty!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be empty!")]
        public string Password { get; set; }
    }
}
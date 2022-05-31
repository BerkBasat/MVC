

namespace MVC_NORTHWIND.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Username cannot be empty!")]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email cannot be empty!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}

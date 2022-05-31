namespace MVC_Sepet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Invalid username!")]
        [Display(Name ="Username")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Invalid Email!")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Invalid Password")]
        [Display(Name ="Password")]
        public string Password { get; set; }
    }
}

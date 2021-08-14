using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Enter an Email")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter a Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a Year")]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Enter a Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords aren't confirmed")]
        public string PasswordConfirm { get; set; }



    }
}

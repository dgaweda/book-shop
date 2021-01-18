using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter your E-mail.")]
        [StringLength(100)]
        [RegularExpression(@"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$", ErrorMessage = "Invalid e-mail. Try example@example.pl")] // Email validation xxxx@xxx.xx
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter your E-mail.")]
        [EmailAddress(ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password.")]
        [StringLength(30, ErrorMessage = "{0} need to have at least {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
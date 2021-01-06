using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Utility
{
    public class Client
    {
        public int ClientID { get; set; }
        public int AddressID { get; set; }
        
        [Required(ErrorMessage = "Enter your name.")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your lastname.")]
        [StringLength(30)]
        public string LastName { get; set; }

        [RegularExpression(@"^(([\+]?[0 - 9]{11})|([0 - 9]{9}))$", ErrorMessage = "Invalid phone number.")] // Phone Number Validation (PL) +48 111 111 111 etc.
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter your E-mail.")]
        [StringLength(100)]
        [RegularExpression(@"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$", ErrorMessage = "Invalid e-mail. Try example@example.pl")] // Email validation xxxx@xxx.xx
        public string Email { get; set; }

        public virtual Address Address { get; set; }
    }
}
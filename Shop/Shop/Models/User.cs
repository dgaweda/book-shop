using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Utility
{
    public class User
    {
        [StringLength(30, ErrorMessage = "Too long")]
        public string Name { get; set; }

        [StringLength(30, ErrorMessage = "Too long")]
        public string LastName { get; set; }

        [RegularExpression(@"^(([\+]?[0-9]{11})|([0-9]{9}))$", ErrorMessage = "Invalid phone number.")] // Phone Number Validation (PL) +48 111 111 111 etc.
        public string PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "Your email is too long")]
        [EmailAddress(ErrorMessage = "Invalid e-mail. Try example@example.pl")]  //(@"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$", ErrorMessage = "Invalid e-mail. Try example@example.pl")] // Email validation xxxx@xxx.xx
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Too long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid street")]
        public string Street { get; set; }
        
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid street number")]
        public int StreetNumber { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid  house number")]
        public int HouseNumber { get; set; }

        [StringLength(6, ErrorMessage = "Too long")]
        //[RegularExpression(@"/^([0-9]{2})(-[0-9]{3})?$/i", ErrorMessage = "Invalid postcode")] //  postcode validation
        public string PostCode { get; set; }

        [StringLength(50, ErrorMessage = "Too long")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid street.")]
        public string City { get; set; }
    }
}
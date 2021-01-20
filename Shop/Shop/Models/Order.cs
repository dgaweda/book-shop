using Shop.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Order
    {
        public int OrderID { get; set; } // PK of Order

        public string UserID { get; set; } // fk of Order
        
        [Required(ErrorMessage = "Enter your name.")]
        [StringLength(30)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter your lastname.")]
        [StringLength(30)]
        public string LastName { get; set; }

       //[RegularExpression(@"^(([\+]?[0 - 9]{11})|([0 - 9]{9}))$", ErrorMessage = "Invalid phone number.")] // Phone Number Validation (PL) +48 111 111 111 etc.
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter street name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid street.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Enter street number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid number.")]
        public int StreetNumber { get; set; }

        [Required(ErrorMessage = "Enter house number")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid number.")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "Fill postcode field")]
        //[RegularExpression(@"^\d{2}(-\d{4})?$", ErrorMessage = "Invalid postcode")] //  postcode validation
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Enter city's name")]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid street.")]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid e-mail. Try example@example.pl")]  //(@"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$", ErrorMessage = "Invalid e-mail. Try example@example.pl")] // Email validation xxxx@xxx.xx
        public string Email { get; set; }
        
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; }
        public Status Status { get; set; } // Received, Done
        public decimal OrderValue { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
        public virtual ApplicationUser User { get; set; }

        

    }

    public enum Status
    {
        Received,
        Done
    }




}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop.Utility
{
    public class Address
    {
        public int AddressID { get; set; }
        public int ClientID { get; set; }
        
        [Required(ErrorMessage = "Enter street name")]
        [StringLength(50)]
        public string Street { get; set; }
        
        [Required(ErrorMessage = "Enter street number")]
        public int StreetNumber { get; set; }

        [Required(ErrorMessage = "Enter house number")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "Fill postcode field")]
        [RegularExpression(@"^\d{2}(-\d{4})?$", ErrorMessage = "Invalid postcode")] //  postcode validation
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Enter city's name")]
        public string City { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
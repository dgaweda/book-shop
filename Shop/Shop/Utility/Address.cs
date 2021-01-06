using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Utility
{
    public class Address
    {
        public int AddressID { get; set; }
        public int ClientID { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
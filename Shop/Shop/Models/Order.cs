using Shop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public Client Client { get; set; }
        public Address Address { get; set; }
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; }
        public Status Status { get; set; }
        public decimal OrderValue { get; set; }
        
        List<OrderPosition> OrderPositions { get; set; }
    }

    public enum Status
    { 
        New,
        Done
    }
}
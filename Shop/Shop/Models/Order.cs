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
        public int UserID { get; set; } // FK of Client
        public string Comment { get; set; }
        public DateTime DateAdded { get; set; }
        public Status Status { get; set; } // Received, Done
        public decimal OrderValue { get; set; }
        
        public virtual User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }

    public enum Status
    { 
        Received,
        Done
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
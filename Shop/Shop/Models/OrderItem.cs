using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class OrderItem
    {
        public int OrderItemID { get; set; } // PK
        public int OrderID { get; set; } // FK of ORDER
        public int BookID { get; set; } // FK of Book
        public int Quantity { get; set; }
        public decimal Value { get; set; } // may change after promotion for ex. 10%

        public virtual Book book { get; set; }
        public virtual Order Order { get; set; }
    }
}
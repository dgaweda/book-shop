using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class OrderPosition
    {
        public int OrderPositionID { get; set; } // PK
        public int OrderID { get; set; } // FK of ORDER
        public int BookID { get; set; } // FK of Book
        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; } // may change after promo

        public virtual Book book { get; set; }
        public virtual Order Order { get; set; }
    }
}
namespace Shop.Models
{
    public class OrderPosition
    {
        public int OrderPositionID { get; set; }
        public int OrderID { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public decimal BuyPrice { get; set; } // EX. after promo

        public virtual Book book { get; set; }
        public virtual Order Order { get; set; }
    }
}
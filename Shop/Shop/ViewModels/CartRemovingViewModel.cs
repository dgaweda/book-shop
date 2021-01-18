using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.ViewModels
{
    public class CartRemovingViewModel
    {
        public decimal CartFinalPrice { get; set; }
        public int CartCountItems { get; set; }
        public int QuantityOfItemToDelete { get; set; }
        public int IdDeletedItem { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime DateAdded { get; set; }
        public string IcoName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Bestseller { get; set; }
        public bool Hidden { get; set; } // Option for Admin, beneath deleting it from TAB, jus hide it
    }
}
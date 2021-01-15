using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Category> Categories { get; set; } // Generic type that every collection returns
        public IEnumerable<Book> Newest { get; set; }
        public IEnumerable<Book> Bestsellers { get; set; }
    }
}
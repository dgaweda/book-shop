using Shop.Contexts;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private ShopContext db = new ShopContext();
        
        // GET: Home
        public ActionResult Index()
        {
            var categories = db.Categories.ToList();
            
            var newest = db.Books
                .Where(b => !b.Hidden)
                .OrderByDescending(b => b.DateAdded)
                .Take(3).ToList();
            
            var bestsellers = db.Books
                .Where(b => !b.Hidden && b.Bestseller)
                .OrderBy(b => Guid.NewGuid())
                .Take(3)
                .ToList();

            var VM = new HomeViewModel()
            {
                Categories = categories,
                Newest = newest,
                Bestsellers = bestsellers
            };
            
            return View(VM);
        }
    }
}
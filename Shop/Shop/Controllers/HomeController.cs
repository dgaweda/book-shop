using Shop.Contexts;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private BooksContext db = new BooksContext();
        
        // GET: Home
        public ActionResult Index()
        {
            Category category = new Category { Name = "Criminal", Description = "xyz", IcoName = "criminal.png" };
            db.Categories.Add(category);
            db.SaveChanges();

            return View();
        }
    }
}
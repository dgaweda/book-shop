using Shop.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class BookController : Controller
    {
        private ShopContext db = new ShopContext();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(string Name)
        {
            var categories = db.Categories
                .Include("Books")
                .Where(c => c.Name.ToUpper() == Name.ToUpper())
                .Single(); //
            var books = categories.Books.ToList();
            return View(books);
        }

        public ActionResult Details(string Id)
        {
            return View();
        }
        [ChildActionOnly] // wywowalnie z poziomu innej akcji
        public ActionResult CategoriesMenu() 
        {
            var categories = db.Categories.ToList(); // ref categories to partial view
            return PartialView("_CategoriesMenu", categories);
        }
    }
}
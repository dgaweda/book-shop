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
        private ShopContext db = new ShopContext();
        
        // GET: Home
        public ActionResult Index()
        {
            var categoriesList = db.Categories.ToList();
            return View();
        }
    }
}
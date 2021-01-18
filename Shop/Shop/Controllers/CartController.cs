using Shop.Contexts;
using Shop.Infrastructure;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private CartManager _cartManager;
        private ISessionManager _sessionManager { get; set; }
        private ShopContext db = new ShopContext();
        // GET: Cart

        public CartController()
        {
            _sessionManager = new SessionManager();
            _cartManager = new CartManager(_sessionManager, db);
        }
        public ActionResult CartIndex()
        {
            var cartItems = _cartManager.GetCart();
            var finalPrice = _cartManager.GetCartValue();

            CartViewModel cartVM = new CartViewModel()
            {
                CartItems = cartItems,
                FinalPrice = finalPrice
            };
            return View(cartVM);
        }

        public ActionResult AddToCart(int id)
        {
            _cartManager.Add(id);
            return RedirectToAction("CartIndex");
        }

        public int GetQuantityOfCartItems()
        {
            return _cartManager.GetQuantityOfCartItems();
        }

        public ActionResult Remove(int BookId)
        {
            int quantityOfItems = _cartManager.Remove(BookId);
            int quantityOfCartItems = _cartManager.GetQuantityOfCartItems();
            decimal cartValue = _cartManager.GetCartValue();

            var result = new CartRemovingViewModel
            {
                IdDeletedItem = BookId,
                QuantityOfItemToDelete = quantityOfItems,
                CartFinalPrice = cartValue,
                CartCountItems = quantityOfCartItems
            };

            return Json(result);
        }
    }
}
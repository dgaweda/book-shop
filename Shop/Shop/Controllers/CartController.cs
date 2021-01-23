using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Shop.App_Start;
using Shop.Contexts;
using Shop.Infrastructure;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private CartManager _cartManager;
        private ApplicationUserManager _userManager;

        private ISessionManager _sessionManager { get; set; }
        private ShopContext db = new ShopContext();

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
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

        public ActionResult Clear()
        {
            _cartManager.ClearCart();

            return RedirectToAction("CartIndex");
        }

        public ActionResult Remove(int BookId)
        {
            int quantityOfItems = _cartManager.Remove(BookId);
            int quantityOfCartItems = _cartManager.GetQuantityOfCartItems();
            decimal cartValue = _cartManager.GetCartValue();

            var cart = _cartManager.GetCart();
            var result = new CartViewModel
            {
                CartItems = cart,
                FinalPrice = cartValue
            };


            return View("CartIndex", result);
        }

        public async Task<ActionResult> Pay()
        {
            if (Request.IsAuthenticated) // czy jest zalogowany
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

                var order = new Order
                {
                    Name = user.User.Name,
                    LastName = user.User.LastName,
                    PhoneNumber = user.User.PhoneNumber,
                    Street = user.User.Street,
                    StreetNumber = user.User.StreetNumber,
                    HouseNumber = user.User.HouseNumber,
                    PostCode = user.User.PostCode,
                    City = user.User.City,
                    Email = user.User.Email
                };
                return View(order);
            }
            else
            {
                return RedirectToAction("Login", "Account", new { returnurl = Url.Action("Pay", "Cart") });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Pay(Order order)
        {
            if (ModelState.IsValid)
            {
                // get id of user
                var userId = User.Identity.GetUserId();

                // creating order based on cart
                var newOrder = _cartManager.CreateOrder(order, userId);

                // user details
                var user = await UserManager.FindByIdAsync(userId);
                TryUpdateModel(user.User);
                await UserManager.UpdateAsync(user);

                // delete cart
                _cartManager.ClearCart();

                return RedirectToAction("OrderConfirm");
            }
            else
            {
                return View(order);
            }
        }

        public ActionResult OrderConfirm()
        {
            return View();
        }
    }
}
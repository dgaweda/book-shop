using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Shop.App_Start;
using Shop.Contexts;
using Shop.Models;
using Shop.Utility;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ManageController : Controller
    {
        private ApplicationUserManager _userManager;
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

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            Error
        }
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> ManageIndex(ManageMessageId? message) 
        {
            if (TempData["ViewData"] != null)
            {
                ViewData = (ViewDataDictionary)TempData["ViewData"];
            }

            if (User.IsInRole("Admin"))
            {
                ViewBag.UserIsAdmin = true;
            }
            else
            {
                ViewBag.UserIsAdmin = false;
            }

            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }

            var model = new ManageCredentialsViewModel
            {
                Message = message,
                User = user.User
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeProfile([Bind(Prefix = "User")] User user)
        {
            if (ModelState.IsValid)
            {
                var _user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                _user.User = user;
                var result = await UserManager.UpdateAsync(_user);

                AddErrors(result);
            }

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("ManageIndex");
            }

            var message = "Data Updated Successfully";
            return RedirectToAction("ManageIndex", new { Message = message});
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword([Bind(Prefix = "ChangePasswordViewModel")]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) // check form
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("ManageIndex");
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInAsync(user, isPersistent: false);
                }
                return RedirectToAction("ManageIndex", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);

            if (!ModelState.IsValid)
            {
                TempData["ViewData"] = ViewData;
                return RedirectToAction("ManageIndex");
            }

            var message = ManageMessageId.ChangePasswordSuccess;
            return RedirectToAction("ManageIndex");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("password-error", error);
            }
        }

        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, await user.GenerateUserIdentityAsync(UserManager));
        }

        public ActionResult OrderList()
        {
            bool IsAdmin = User.IsInRole("Admin");
            ViewBag.UserIsAdmin = IsAdmin; // ref to view

            IEnumerable<Order> UserOrders;

            if (IsAdmin) // for admin get all
            {
                UserOrders = db.Orders.Include("OrderItems")
                    .OrderByDescending(o => o.DateAdded)
                    .ToList();
            }
            else
            {
                var userId = User.Identity.GetUserId();
                UserOrders = db.Orders.Where(o => o.UserID == userId)
                    .Include("OrderItems")
                    .OrderByDescending(o => o.DateAdded)
                    .ToList();
            }

            return View(UserOrders);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public Status OrderStatusChange(Order order)
        {
            Order findOrder = db.Orders.Find(order.OrderID);
            findOrder.Status = order.Status;
            db.SaveChanges();

            return order.Status;
        }
    }
}
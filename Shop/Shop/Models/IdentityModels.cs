using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Shop.Models
{
    public class IdentityModels
    {
        public virtual ICollection<Order> Orders { get; set; }
        public User UserData { get; set; }
        public class ApplicationUser : IdentityUser
        {
            public User User { get; set; }
            public virtual ICollection<Order> Order { get; set; }
            
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        }
    }
}
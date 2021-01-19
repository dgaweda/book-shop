using Microsoft.AspNet.Identity.EntityFramework;
//using Shop.Initializer;
using Shop.Models;
using Shop.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Shop.Contexts
{
    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        
        public ShopContext() : base("Books") // Constructor when connectionstring(database) is extracted
        {
                
        }
        
        static ShopContext()
        {
           // Database.SetInitializer<ShopContext>(new ShopInitilizer()); // Init Default Data to Database
        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
        // Added Tables
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); // Disables adding "s" convention to table names like Books + s = Bookss

        }
    }
}
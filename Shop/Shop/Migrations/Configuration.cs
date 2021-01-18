namespace Shop.Migrations
{
    using Shop.Initializer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Shop.Contexts.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Shop.Contexts.ShopContext";
        }

        protected override void Seed(Shop.Contexts.ShopContext context)
        {
            ShopInitilizer.SeedShopData(context);
        }
    }
}

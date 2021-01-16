using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Shop.Contexts;
using Shop.Models;
using Shop.Migrations;
using System.Data.Entity.Migrations;

namespace Shop.Initializer
{
    public class ShopInitilizer : MigrateDatabaseToLatestVersion<ShopContext, Configuration> // do not delete db - keep data in db even if my app is off (Migrate DB to newest version)
    {
        public static void SeedShopData(ShopContext context)
        {
            string DescriptionExample = "Action and adventure books constantly have you on the edge of your seat with excitement, as your fave main character repeatedly finds themselves in high stakes situations. The protagonist has an ultimate goal to achieve and is always put in risky, often dangerous situations. This genre typically crosses over with others like mystery, crime, sci-fi, and fantasy";
            string ShortDescriptionExample = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            var Categories = new List<Category>
            {
                    new Category() { CategoryID = 1,Name = "Action and Adventure",Description = DescriptionExample, IcoName = "list-point.png" },
                    new Category() { CategoryID = 2,Name = "Classics", Description = DescriptionExample, IcoName = "list-point.png" },
                    new Category() { CategoryID = 3,Name = "Comic Book", Description = DescriptionExample, IcoName = "list-point.png" },
                    new Category() { CategoryID = 4,Name = "Detective and Mystery", Description = DescriptionExample,IcoName = "list-point.png"},
                    new Category() { CategoryID = 5,Name = "Fantasy", Description = DescriptionExample, IcoName = "list-point.png" }
            };
            Categories.ForEach(category => context.Categories.AddOrUpdate(category)); // NO DUPLICATES IN DB
            context.SaveChanges();

            var Books = new List<Book>
            {
                new Book() {BookId = 1, CategoryId = 1, Title = "Life of Pi", Author = "Yann Martel",DateAdded = DateTime.Now, IcoName = "lifeOfPi.jpg", Description = ShortDescriptionExample, Price = 4 ,Bestseller = true, Hidden = false },
                new Book() {BookId = 2 ,CategoryId = 2, Title = "Little Women", Author = "Alcott May Louisa",DateAdded = DateTime.Now, IcoName = "little-woman.jpg", Description = ShortDescriptionExample, Price = 4 ,Bestseller = true, Hidden = false },
                new Book() {BookId = 3 ,CategoryId = 3, Title = "The Walking Dead: Compendium One",Author = "Robert Kirkman",DateAdded = DateTime.Now, IcoName = "the-walking-dead.jpg", Description = ShortDescriptionExample, Price = 4 , Bestseller = true, Hidden = false },
                new Book() {BookId = 4 ,CategoryId = 4, Title = "Harry Potter", Author = "J.K. Rowling",DateAdded = DateTime.Now, IcoName = "harry-potter.jpg", Description = ShortDescriptionExample, Price = 4 ,Bestseller = false, Hidden = false },
                new Book() {BookId = 5 ,CategoryId = 5, Title = "Test",Author = "Dariusz Gaweda",DateAdded = DateTime.Now, IcoName = "test.jpg", Description = ShortDescriptionExample, Price = 4 , Bestseller = false, Hidden = false }
            };
            Books.ForEach(book => context.Books.AddOrUpdate(book)); // NO DUPLICATES IN DB
            context.SaveChanges();
        }
    }
}
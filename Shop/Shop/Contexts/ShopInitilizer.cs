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
            string ActionAndAdventureDescription = "Action and adventure books constantly have you on the edge of your seat with excitement, as your fave main character repeatedly finds themselves in high stakes situations. The protagonist has an ultimate goal to achieve and is always put in risky, often dangerous situations. This genre typically crosses over with others like mystery, crime, sci-fi, and fantasy.";
            string ClassicsDescription = "You may think of these books as the throwback readings you were assigned in English class. (Looking at you, Charles Dickens.) The classics have been around for decades, and were often groundbreaking stories at their publish time, but have continued to be impactful for generations, serving as the foundation for many popular works we read today.";
            string ComicsDescription = "The stories in comic books and graphic novels are presented to the reader through engaging, sequential narrative art (illustrations and typography) that's either presented in a specific design or the traditional panel layout you find in comics. With both, you'll often find the dialogue presented in the tell-tale word ballons next to the respective characters.";

            string LifeOfPiDescription = "The son of a zookeeper, Pi Patel has an encyclopedic knowledge of animal behavior and a fervent love of stories. When Pi is sixteen, his family emigrates from India to North America aboard a Japanese cargo ship, along with their zoo animals bound for new homes.";
            var Categories = new List<Category>
            {
                    new Category() { CategoryID = 1,Name = "Action and Adventure",Description= ActionAndAdventureDescription, IcoName = "romans.png" },
                    new Category() { CategoryID = 2,Name = "Classics", Description = ClassicsDescription, IcoName = "romans.png" },
                    new Category() { CategoryID = 3,Name = "Comic Book",Description = ComicsDescription, IcoName = "romans.png" },
                    /*new Category ( 4, "Detective and Mystery","Romans", "romans.png"),
                    new Category ( 5, "Fantasy","Romans", "romans.png"),
                    new Category ( 6, "Historical Fiction","Romans", "romans.png"),
                    new Category ( 7, "Horror","Romans", "romans.png"),
                    new Category ( 8, "Literary Fiction","Romans", "romans.png"),
                    new Category ( 9, "Romance","Romans", "romans.png"),
                    new Category ( 10, "Sci-Fi","Romans", "romans.png"),
                    new Category ( 11, "Short Stories","Romans", "romans.png"),
                    new Category ( 12, "Thriller","Romans", "romans.png"),
                    new Category ( 13, "Biographies and Autobiographies","Romans", "romans.png"),
                    new Category ( 14, "Cookbooks","Romans", "romans.png"),*/
            };
            Categories.ForEach(category => context.Categories.AddOrUpdate(category)); // NO DUPLICATES IN DB
            context.SaveChanges();

            var Books = new List<Book>
            {
                new Book() {BookId = 1, CategoryId = 1, Title = "Life of Pi", Author = "Yann Martel",DateAdded = DateTime.Now, IcoName = "life_of_pi.png", Description = LifeOfPiDescription, Price = 4 ,Bestseller = true, Hidden = false },
                new Book() {BookId = 2 ,CategoryId = 2,Title = "Little Women", Author = "Alcott May Louisa",DateAdded = DateTime.Now, IcoName = "life_of_pi.png", Description = LifeOfPiDescription, Price = 4 ,Bestseller = true, Hidden = false },
                new Book() {BookId = 3 ,CategoryId = 3,Title = "The Wolking Dead: Compendium One",Author = "Yann Martel",DateAdded = DateTime.Now, IcoName = "life_of_pi.png", Description = LifeOfPiDescription, Price = 4 , Bestseller = true, Hidden = false }
            };
            Books.ForEach(book => context.Books.AddOrUpdate(book)); // NO DUPLICATES IN DB
            context.SaveChanges();
        }
    }
}
namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INIT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        Street = c.String(nullable: false, maxLength: 50),
                        StreetNumber = c.Int(nullable: false),
                        HouseNumber = c.Int(nullable: false),
                        PostCode = c.String(nullable: false),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        AddressID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Address", t => t.AddressID, cascadeDelete: true)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Author = c.String(nullable: false, maxLength: 100),
                        DateAdded = c.DateTime(nullable: false),
                        IcoName = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                        ShortDescription = c.String(),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false),
                        IcoName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        OrderItemID = c.Int(nullable: false, identity: true),
                        OrderID = c.Int(nullable: false),
                        BookID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemID)
                .ForeignKey("dbo.Book", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        ClientID = c.Int(nullable: false),
                        Comment = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Client", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItem", "OrderID", "dbo.Order");
            DropForeignKey("dbo.Order", "ClientID", "dbo.Client");
            DropForeignKey("dbo.OrderItem", "BookID", "dbo.Book");
            DropForeignKey("dbo.Book", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Client", "AddressID", "dbo.Address");
            DropIndex("dbo.Order", new[] { "ClientID" });
            DropIndex("dbo.OrderItem", new[] { "BookID" });
            DropIndex("dbo.OrderItem", new[] { "OrderID" });
            DropIndex("dbo.Book", new[] { "CategoryId" });
            DropIndex("dbo.Client", new[] { "AddressID" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderItem");
            DropTable("dbo.Category");
            DropTable("dbo.Book");
            DropTable("dbo.Client");
            DropTable("dbo.Address");
        }
    }
}

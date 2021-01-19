namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Name", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Order", "LastName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Order", "PhoneNumber", c => c.String());
            AddColumn("dbo.Order", "Street", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Order", "StreetNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "HouseNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "PostCode", c => c.String(nullable: false));
            AddColumn("dbo.Order", "City", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Order", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Order", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String(maxLength: 50));
            CreateIndex("dbo.Order", "UserID");
            AddForeignKey("dbo.Order", "UserID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Order", "User_Name");
            DropColumn("dbo.Order", "User_LastName");
            DropColumn("dbo.Order", "User_PhoneNumber");
            DropColumn("dbo.Order", "User_Email");
            DropColumn("dbo.Order", "User_Street");
            DropColumn("dbo.Order", "User_StreetNumber");
            DropColumn("dbo.Order", "User_HouseNumber");
            DropColumn("dbo.Order", "User_PostCode");
            DropColumn("dbo.Order", "User_City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "User_City", c => c.String());
            AddColumn("dbo.Order", "User_PostCode", c => c.String());
            AddColumn("dbo.Order", "User_HouseNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "User_StreetNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Order", "User_Street", c => c.String());
            AddColumn("dbo.Order", "User_Email", c => c.String());
            AddColumn("dbo.Order", "User_PhoneNumber", c => c.String());
            AddColumn("dbo.Order", "User_LastName", c => c.String());
            AddColumn("dbo.Order", "User_Name", c => c.String());
            DropForeignKey("dbo.Order", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Order", new[] { "UserID" });
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_Email", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String());
            AlterColumn("dbo.Order", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Order", "Email");
            DropColumn("dbo.Order", "City");
            DropColumn("dbo.Order", "PostCode");
            DropColumn("dbo.Order", "HouseNumber");
            DropColumn("dbo.Order", "StreetNumber");
            DropColumn("dbo.Order", "Street");
            DropColumn("dbo.Order", "PhoneNumber");
            DropColumn("dbo.Order", "LastName");
            DropColumn("dbo.Order", "Name");
        }
    }
}

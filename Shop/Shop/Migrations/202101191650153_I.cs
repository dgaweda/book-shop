namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class I : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Order", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Order", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Order", "ApplicationUser_Id");
            AddForeignKey("dbo.Order", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

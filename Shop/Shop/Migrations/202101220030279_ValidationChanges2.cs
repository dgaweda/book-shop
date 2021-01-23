namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationChanges2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_PhoneNumber", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "User_PostCode", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "User_PostCode", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "User_Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "User_PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}

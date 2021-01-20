namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PermissionChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "User_City", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "User_City", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(maxLength: 30));
        }
    }
}

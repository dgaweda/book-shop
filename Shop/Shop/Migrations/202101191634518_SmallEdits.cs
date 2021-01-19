namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallEdits : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "User_Name", c => c.String());
            AlterColumn("dbo.Order", "User_LastName", c => c.String());
            AlterColumn("dbo.Order", "User_Email", c => c.String());
            AlterColumn("dbo.Order", "User_Street", c => c.String());
            AlterColumn("dbo.Order", "User_City", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_Email", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_City", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "User_City", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "User_Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.Order", "User_City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Order", "User_Street", c => c.String(maxLength: 50));
            AlterColumn("dbo.Order", "User_Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.Order", "User_LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Order", "User_Name", c => c.String(maxLength: 30));
        }
    }
}

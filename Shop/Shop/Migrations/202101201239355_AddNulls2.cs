namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNulls2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String(maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "User_PostCode", c => c.String(maxLength: 6));
            AlterColumn("dbo.AspNetUsers", "User_City", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "User_City", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_PostCode", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_Street", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_LastName", c => c.String());
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String());
        }
    }
}

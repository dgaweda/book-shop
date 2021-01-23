namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationChanges3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "User_City", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "User_City", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingRequiredValue : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "User_Name", c => c.String(maxLength: 30));
        }
    }
}

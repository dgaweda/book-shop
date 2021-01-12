namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Test");
        }
    }
}

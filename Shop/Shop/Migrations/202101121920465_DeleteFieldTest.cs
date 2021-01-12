namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteFieldTest : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Book", "Test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "Test", c => c.String());
        }
    }
}

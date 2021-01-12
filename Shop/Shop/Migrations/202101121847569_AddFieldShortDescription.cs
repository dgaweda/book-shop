namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldShortDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "ShortDescription");
        }
    }
}

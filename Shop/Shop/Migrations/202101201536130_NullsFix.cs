namespace Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullsFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Order", "Email", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Order", "Email", c => c.String(maxLength: 100));
        }
    }
}

namespace LibraryAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIncorrectProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "MyProperty", c => c.Int(nullable: false));
        }
    }
}

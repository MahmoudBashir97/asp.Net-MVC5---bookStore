namespace _Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsetupChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false, maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false, maxLength: 128));
        }
    }
}

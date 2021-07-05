namespace _Books.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChangeCategoryName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "FehresList");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FehresList", newName: "Categories");
        }
    }
}

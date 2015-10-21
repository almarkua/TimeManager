namespace TimeManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UsersPublicCategories", name: "CategotyId", newName: "CategoryId");
            RenameIndex(table: "dbo.UsersPublicCategories", name: "IX_CategotyId", newName: "IX_CategoryId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UsersPublicCategories", name: "IX_CategoryId", newName: "IX_CategotyId");
            RenameColumn(table: "dbo.UsersPublicCategories", name: "CategoryId", newName: "CategotyId");
        }
    }
}

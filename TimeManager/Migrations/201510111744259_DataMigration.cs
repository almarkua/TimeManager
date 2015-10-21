namespace TimeManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.PublicCategoryUsers", newName: "UsersPublicCategories");
            RenameColumn(table: "dbo.UsersPublicCategories", name: "PublicCategory_PublicCategoryId", newName: "CategotyId");
            RenameColumn(table: "dbo.UsersPublicCategories", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.UsersPublicCategories", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.UsersPublicCategories", name: "IX_PublicCategory_PublicCategoryId", newName: "IX_CategotyId");
            DropPrimaryKey("dbo.UsersPublicCategories");
            AddPrimaryKey("dbo.UsersPublicCategories", new[] { "UserId", "CategotyId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UsersPublicCategories");
            AddPrimaryKey("dbo.UsersPublicCategories", new[] { "PublicCategory_PublicCategoryId", "User_Id" });
            RenameIndex(table: "dbo.UsersPublicCategories", name: "IX_CategotyId", newName: "IX_PublicCategory_PublicCategoryId");
            RenameIndex(table: "dbo.UsersPublicCategories", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.UsersPublicCategories", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.UsersPublicCategories", name: "CategotyId", newName: "PublicCategory_PublicCategoryId");
            RenameTable(name: "dbo.UsersPublicCategories", newName: "PublicCategoryUsers");
        }
    }
}

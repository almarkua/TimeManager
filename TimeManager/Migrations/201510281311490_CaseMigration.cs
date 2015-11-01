namespace TimeManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Todos", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Todos", new[] { "Category_CategoryId" });
            CreateTable(
                "dbo.Todoes",
                c => new
                    {
                        TodoId = c.Int(nullable: false, identity: true),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.TodoId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            DropTable("dbo.Todos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Todos",
                c => new
                    {
                        TodoId = c.Int(nullable: false, identity: true),
                        ShortDescription = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Priority = c.Int(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.TodoId);
            
            DropForeignKey("dbo.Todoes", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.Todoes", new[] { "Category_CategoryId" });
            DropTable("dbo.Todoes");
            CreateIndex("dbo.Todos", "Category_CategoryId");
            AddForeignKey("dbo.Todos", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}

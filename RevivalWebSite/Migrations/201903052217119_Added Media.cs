namespace RevivalWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMedia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Title_ENG = c.String(maxLength: 50),
                        Description = c.String(),
                        Description_ENG = c.String(),
                        VideoURL = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MediaCategory", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.MediaCategory",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 25),
                        Title_ENG = c.String(maxLength: 25),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Media", "CategoryID", "dbo.MediaCategory");
            DropIndex("dbo.Media", new[] { "CategoryID" });
            DropTable("dbo.MediaCategory");
            DropTable("dbo.Media");
        }
    }
}

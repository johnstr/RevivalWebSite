namespace RevivalWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newstables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.Event", "Name_ENG", c => c.String(maxLength: 50));
            AddColumn("dbo.Media", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.MediaCategory", "Name", c => c.String(maxLength: 25));
            AddColumn("dbo.MediaCategory", "Name_ENG", c => c.String(maxLength: 25));
            AlterColumn("dbo.Media", "PostDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Event", "Title");
            DropColumn("dbo.Event", "Title_ENG");
            DropColumn("dbo.Media", "Title");
            DropColumn("dbo.Media", "Title_ENG");
            DropColumn("dbo.Media", "Description_ENG");
            DropColumn("dbo.MediaCategory", "Title");
            DropColumn("dbo.MediaCategory", "Title_ENG");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MediaCategory", "Title_ENG", c => c.String(maxLength: 25));
            AddColumn("dbo.MediaCategory", "Title", c => c.String(maxLength: 25));
            AddColumn("dbo.Media", "Description_ENG", c => c.String());
            AddColumn("dbo.Media", "Title_ENG", c => c.String(maxLength: 50));
            AddColumn("dbo.Media", "Title", c => c.String(maxLength: 50));
            AddColumn("dbo.Event", "Title_ENG", c => c.String(maxLength: 50));
            AddColumn("dbo.Event", "Title", c => c.String(maxLength: 50));
            AlterColumn("dbo.Media", "PostDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.MediaCategory", "Name_ENG");
            DropColumn("dbo.MediaCategory", "Name");
            DropColumn("dbo.Media", "Name");
            DropColumn("dbo.Event", "Name_ENG");
            DropColumn("dbo.Event", "Name");
        }
    }
}

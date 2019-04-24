namespace RevivalWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkerrors : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Media", "PostDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Media", "PostDate", c => c.DateTime(nullable: false));
        }
    }
}

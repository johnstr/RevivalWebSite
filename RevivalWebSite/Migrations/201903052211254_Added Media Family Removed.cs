namespace RevivalWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMediaFamilyRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Family", "AddressID", "dbo.Address");
            DropForeignKey("dbo.Child", "FamilyID", "dbo.Family");
            DropForeignKey("dbo.Parent", "FamilyID", "dbo.Family");
            DropForeignKey("dbo.Event", "MinistryID", "dbo.Ministry");
            DropIndex("dbo.Child", new[] { "FamilyID" });
            DropIndex("dbo.Family", new[] { "AddressID" });
            DropIndex("dbo.Parent", new[] { "FamilyID" });
            DropIndex("dbo.Event", new[] { "MinistryID" });
            AddColumn("dbo.Child", "ParentID", c => c.Int(nullable: false));
            AddColumn("dbo.Parent", "About", c => c.String());
            AddColumn("dbo.Parent", "AddressID", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "Title_ENG", c => c.String(maxLength: 50));
            AddColumn("dbo.Event", "About_ENG", c => c.String());
            AddColumn("dbo.Event", "Location", c => c.String());
            AddColumn("dbo.Event", "Location_ENG", c => c.String());
            AlterColumn("dbo.Event", "Title", c => c.String(maxLength: 50));
            CreateIndex("dbo.Child", "ParentID");
            CreateIndex("dbo.Parent", "AddressID");
            AddForeignKey("dbo.Parent", "AddressID", "dbo.Address", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Child", "ParentID", "dbo.Parent", "ID", cascadeDelete: true);
            DropColumn("dbo.Child", "FamilyID");
            DropColumn("dbo.Parent", "Email");
            DropColumn("dbo.Parent", "FamilyID");
            DropColumn("dbo.Event", "MinistryID");
            DropTable("dbo.Family");
            DropTable("dbo.Ministry");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ministry",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Family",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(maxLength: 50),
                        About = c.String(),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Event", "MinistryID", c => c.Int(nullable: false));
            AddColumn("dbo.Parent", "FamilyID", c => c.Int(nullable: false));
            AddColumn("dbo.Parent", "Email", c => c.String());
            AddColumn("dbo.Child", "FamilyID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Child", "ParentID", "dbo.Parent");
            DropForeignKey("dbo.Parent", "AddressID", "dbo.Address");
            DropIndex("dbo.Parent", new[] { "AddressID" });
            DropIndex("dbo.Child", new[] { "ParentID" });
            AlterColumn("dbo.Event", "Title", c => c.String());
            DropColumn("dbo.Event", "Location_ENG");
            DropColumn("dbo.Event", "Location");
            DropColumn("dbo.Event", "About_ENG");
            DropColumn("dbo.Event", "Title_ENG");
            DropColumn("dbo.Parent", "AddressID");
            DropColumn("dbo.Parent", "About");
            DropColumn("dbo.Child", "ParentID");
            CreateIndex("dbo.Event", "MinistryID");
            CreateIndex("dbo.Parent", "FamilyID");
            CreateIndex("dbo.Family", "AddressID");
            CreateIndex("dbo.Child", "FamilyID");
            AddForeignKey("dbo.Event", "MinistryID", "dbo.Ministry", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Parent", "FamilyID", "dbo.Family", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Child", "FamilyID", "dbo.Family", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Family", "AddressID", "dbo.Address", "ID", cascadeDelete: true);
        }
    }
}

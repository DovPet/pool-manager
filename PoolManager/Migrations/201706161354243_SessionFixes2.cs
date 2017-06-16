namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionFixes2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sessions", "DrillSet_Id", "dbo.DrillSets");
            DropIndex("dbo.Sessions", new[] { "DrillSet_Id" });
            RenameColumn(table: "dbo.Sessions", name: "DrillSet_Id", newName: "DrillSetId");
            AlterColumn("dbo.Sessions", "DrillSetId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sessions", "DrillSetId");
            AddForeignKey("dbo.Sessions", "DrillSetId", "dbo.DrillSets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "DrillSetId", "dbo.DrillSets");
            DropIndex("dbo.Sessions", new[] { "DrillSetId" });
            AlterColumn("dbo.Sessions", "DrillSetId", c => c.Int());
            RenameColumn(table: "dbo.Sessions", name: "DrillSetId", newName: "DrillSet_Id");
            CreateIndex("dbo.Sessions", "DrillSet_Id");
            AddForeignKey("dbo.Sessions", "DrillSet_Id", "dbo.DrillSets", "Id");
        }
    }
}

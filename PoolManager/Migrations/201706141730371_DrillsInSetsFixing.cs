namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrillsInSetsFixing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DrillsInSets", "Drill_Id", "dbo.Drills");
            DropForeignKey("dbo.DrillsInSets", "DrillSet_Id", "dbo.DrillSets");
            DropIndex("dbo.DrillsInSets", new[] { "Drill_Id" });
            DropIndex("dbo.DrillsInSets", new[] { "DrillSet_Id" });
            RenameColumn(table: "dbo.DrillsInSets", name: "Drill_Id", newName: "DrillId");
            RenameColumn(table: "dbo.DrillsInSets", name: "DrillSet_Id", newName: "DrillSetId");
            AlterColumn("dbo.DrillsInSets", "DrillId", c => c.Int(nullable: false));
            AlterColumn("dbo.DrillsInSets", "DrillSetId", c => c.Int(nullable: false));
            CreateIndex("dbo.DrillsInSets", "DrillId");
            CreateIndex("dbo.DrillsInSets", "DrillSetId");
            AddForeignKey("dbo.DrillsInSets", "DrillId", "dbo.Drills", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DrillsInSets", "DrillSetId", "dbo.DrillSets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrillsInSets", "DrillSetId", "dbo.DrillSets");
            DropForeignKey("dbo.DrillsInSets", "DrillId", "dbo.Drills");
            DropIndex("dbo.DrillsInSets", new[] { "DrillSetId" });
            DropIndex("dbo.DrillsInSets", new[] { "DrillId" });
            AlterColumn("dbo.DrillsInSets", "DrillSetId", c => c.Int());
            AlterColumn("dbo.DrillsInSets", "DrillId", c => c.Int());
            RenameColumn(table: "dbo.DrillsInSets", name: "DrillSetId", newName: "DrillSet_Id");
            RenameColumn(table: "dbo.DrillsInSets", name: "DrillId", newName: "Drill_Id");
            CreateIndex("dbo.DrillsInSets", "DrillSet_Id");
            CreateIndex("dbo.DrillsInSets", "Drill_Id");
            AddForeignKey("dbo.DrillsInSets", "DrillSet_Id", "dbo.DrillSets", "Id");
            AddForeignKey("dbo.DrillsInSets", "Drill_Id", "dbo.Drills", "Id");
        }
    }
}

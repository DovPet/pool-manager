namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrillSetMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrillsInSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        Drill_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drills", t => t.Drill_Id)
                .Index(t => t.Drill_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrillsInSets", "Drill_Id", "dbo.Drills");
            DropIndex("dbo.DrillsInSets", new[] { "Drill_Id" });
            DropTable("dbo.DrillsInSets");
        }
    }
}

namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrillSetMigration2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DrillSets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DrillsInSets", "DrillSet_Id", c => c.Int());
            CreateIndex("dbo.DrillsInSets", "DrillSet_Id");
            AddForeignKey("dbo.DrillsInSets", "DrillSet_Id", "dbo.DrillSets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DrillsInSets", "DrillSet_Id", "dbo.DrillSets");
            DropIndex("dbo.DrillsInSets", new[] { "DrillSet_Id" });
            DropColumn("dbo.DrillsInSets", "DrillSet_Id");
            DropTable("dbo.DrillSets");
        }
    }
}

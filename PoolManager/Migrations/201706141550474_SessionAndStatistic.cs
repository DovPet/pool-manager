namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionAndStatistic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Heading = c.String(nullable: false),
                        Statistics_Id = c.Int(),
                        DrillSet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statistics", t => t.Statistics_Id)
                .ForeignKey("dbo.DrillSets", t => t.DrillSet_Id)
                .Index(t => t.Statistics_Id)
                .Index(t => t.DrillSet_Id);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(nullable: false),
                        SetsDone = c.Int(nullable: false),
                        DrillsDone = c.Int(nullable: false),
                        DrillsFailed = c.Int(nullable: false),
                        DrillSetsFailed = c.Int(nullable: false),
                        DrillSet_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DrillSets", t => t.DrillSet_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.DrillSet_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Statistics", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Statistics", "DrillSet_Id", "dbo.DrillSets");
            DropForeignKey("dbo.Sessions", "DrillSet_Id", "dbo.DrillSets");
            DropForeignKey("dbo.Sessions", "Statistics_Id", "dbo.Statistics");
            DropIndex("dbo.Statistics", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Statistics", new[] { "DrillSet_Id" });
            DropIndex("dbo.Sessions", new[] { "DrillSet_Id" });
            DropIndex("dbo.Sessions", new[] { "Statistics_Id" });
            DropTable("dbo.Statistics");
            DropTable("dbo.Sessions");
        }
    }
}

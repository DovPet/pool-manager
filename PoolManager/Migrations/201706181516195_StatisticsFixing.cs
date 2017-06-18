namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatisticsFixing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Statistics", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Statistics", new[] { "ApplicationUser_Id" });

            DropForeignKey("dbo.Sessions", "Statistics_Id", "dbo.Statistics");
            DropIndex("dbo.Sessions", new[] { "Statistics_Id" });

            RenameColumn(table: "dbo.Statistics", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Statistics", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Statistics", "ApplicationUserId");
            AddForeignKey("dbo.Statistics", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);

            RenameColumn(table: "dbo.Sessions", name: "Statistics_Id", newName: "StatisticsId");
            AlterColumn("dbo.Sessions", "StatisticsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sessions", "StatisticsId");
            AddForeignKey("dbo.Sessions", "StatisticsId", "dbo.Statistics", "Id", cascadeDelete: false);

            AddColumn("dbo.AspNetUsers", "SessionsId", c => c.Int(nullable: true));
            CreateIndex("dbo.AspNetUsers", "SessionsId");
            AddForeignKey("dbo.AspNetUsers", "SessionsId", "dbo.Sessions", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Statistics", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.AspNetUsers", "SessionsId");
            DropColumn("dbo.Sessions", "StatisticsId");
            DropColumn("dbo.Statistics", "ApplicationUserId");
            CreateIndex("dbo.Statistics", "ApplicationUser_Id");
            AddForeignKey("dbo.Statistics", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

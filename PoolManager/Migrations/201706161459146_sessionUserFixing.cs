namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionUserFixing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sessions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Sessions", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.Sessions", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Sessions", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Sessions", "ApplicationUserId");
            AddForeignKey("dbo.Sessions", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sessions", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Sessions", "ApplicationUserId");
            DropIndex("dbo.Sessions", new[] { "ApplicationUserId" });
            CreateIndex("dbo.Sessions", "ApplicationUser_Id");
            AddForeignKey("dbo.Sessions", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropForeignKey("dbo.Sessions", "ApplicationUserId", "dbo.AspNetUsers");
        }
    }
}

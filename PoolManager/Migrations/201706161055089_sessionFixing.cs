namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionFixing : DbMigration
    {
        public override void Up()
        {
            
            AddColumn("dbo.Sessions", "Completed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sessions", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Sessions", "ApplicationUser_Id");
            AddForeignKey("dbo.Sessions", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
           
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Sessions", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Sessions", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Sessions", "ApplicationUser_Id");
            DropColumn("dbo.Sessions", "Completed");
           
        }
    }
}

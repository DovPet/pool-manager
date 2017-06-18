namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterFixing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "SessionsId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "SessionsId", c => c.Int(nullable: false));
        }
    }
}

namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionUserFixing1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sessions", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sessions", "ApplicationUserId", c => c.String());
        }
    }
}

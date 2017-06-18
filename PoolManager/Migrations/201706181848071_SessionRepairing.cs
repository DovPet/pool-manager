namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionRepairing : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sessions", "StatisticsId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sessions", "StatisticsId", c => c.Int(nullable: false));
        }
    }
}

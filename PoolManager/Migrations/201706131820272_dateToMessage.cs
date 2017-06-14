namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateToMessage : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Messages", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "Date", c => c.DateTime());
        }
    }
}

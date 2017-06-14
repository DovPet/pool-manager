namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Date", c => c.DateTime(defaultValueSql: "GETDATE()"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Date");
        }
    }
}

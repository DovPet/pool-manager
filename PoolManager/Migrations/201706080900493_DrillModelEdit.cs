namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrillModelEdit : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drills", "ImageURL");
            DropColumn("dbo.Drills", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drills", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Drills", "ImageURL", c => c.String());
        }
    }
}

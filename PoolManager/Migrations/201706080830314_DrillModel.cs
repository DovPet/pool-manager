namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrillModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Heading = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        ImageURL = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Drills");
        }
    }
}

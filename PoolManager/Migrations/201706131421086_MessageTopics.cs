namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessageTopics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Date = c.DateTime(),
                        MessageTopicId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MessageTopics", t => t.MessageTopicId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.MessageTopicId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.MessageTopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO MessageTopics (Name) VALUES ('Drill Problem')");
            Sql("INSERT INTO MessageTopics (Name) VALUES ('Technical Problem')");
            Sql("INSERT INTO MessageTopics (Name) VALUES ('Suggestion')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "MessageTopicId", "dbo.MessageTopics");
            DropIndex("dbo.Messages", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Messages", new[] { "MessageTopicId" });
            DropTable("dbo.MessageTopics");
            DropTable("dbo.Messages");
        }
    }
}

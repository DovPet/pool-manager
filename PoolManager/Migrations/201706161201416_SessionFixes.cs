namespace PoolManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SessionFixes : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Sessions", name: "DrillSet_Id", newName: "DrillSet_Id");
           
        }
        
        public override void Down()
        {
            
            RenameColumn(table: "dbo.Sessions", name: "DrillSets_Id", newName: "DrillSet_Id");
        }
    }
}

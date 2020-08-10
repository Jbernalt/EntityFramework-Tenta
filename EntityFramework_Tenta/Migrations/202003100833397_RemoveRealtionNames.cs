namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRealtionNames : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Relations", "Firstname");
            DropColumn("dbo.Relations", "Lastname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Relations", "Lastname", c => c.String());
            AddColumn("dbo.Relations", "Firstname", c => c.String());
        }
    }
}

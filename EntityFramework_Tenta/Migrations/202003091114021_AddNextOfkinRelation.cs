namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNextOfkinRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Relations", "NextOfKin_NextOfKinId", c => c.Int());
            CreateIndex("dbo.Relations", "NextOfKin_NextOfKinId");
            AddForeignKey("dbo.Relations", "NextOfKin_NextOfKinId", "dbo.NextOfKins", "NextOfKinId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relations", "NextOfKin_NextOfKinId", "dbo.NextOfKins");
            DropIndex("dbo.Relations", new[] { "NextOfKin_NextOfKinId" });
            DropColumn("dbo.Relations", "NextOfKin_NextOfKinId");
        }
    }
}

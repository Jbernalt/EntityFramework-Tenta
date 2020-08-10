namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredToRealtion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relations", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.Relations", "NextOfKin_NextOfKinId", "dbo.NextOfKins");
            DropIndex("dbo.Relations", new[] { "Camper_CamperId" });
            DropIndex("dbo.Relations", new[] { "NextOfKin_NextOfKinId" });
            AlterColumn("dbo.Relations", "Camper_CamperId", c => c.Int(nullable: false));
            AlterColumn("dbo.Relations", "NextOfKin_NextOfKinId", c => c.Int(nullable: false));
            CreateIndex("dbo.Relations", "Camper_CamperId");
            CreateIndex("dbo.Relations", "NextOfKin_NextOfKinId");
            AddForeignKey("dbo.Relations", "Camper_CamperId", "dbo.Campers", "CamperId", cascadeDelete: true);
            AddForeignKey("dbo.Relations", "NextOfKin_NextOfKinId", "dbo.NextOfKins", "NextOfKinId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relations", "NextOfKin_NextOfKinId", "dbo.NextOfKins");
            DropForeignKey("dbo.Relations", "Camper_CamperId", "dbo.Campers");
            DropIndex("dbo.Relations", new[] { "NextOfKin_NextOfKinId" });
            DropIndex("dbo.Relations", new[] { "Camper_CamperId" });
            AlterColumn("dbo.Relations", "NextOfKin_NextOfKinId", c => c.Int());
            AlterColumn("dbo.Relations", "Camper_CamperId", c => c.Int());
            CreateIndex("dbo.Relations", "NextOfKin_NextOfKinId");
            CreateIndex("dbo.Relations", "Camper_CamperId");
            AddForeignKey("dbo.Relations", "NextOfKin_NextOfKinId", "dbo.NextOfKins", "NextOfKinId");
            AddForeignKey("dbo.Relations", "Camper_CamperId", "dbo.Campers", "CamperId");
        }
    }
}

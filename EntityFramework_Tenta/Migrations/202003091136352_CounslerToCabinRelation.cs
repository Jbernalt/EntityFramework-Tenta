namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CounslerToCabinRelation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Counslers");
            AlterColumn("dbo.Counslers", "CounslerId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Counslers", "CounslerId");
            CreateIndex("dbo.Counslers", "CounslerId");
            AddForeignKey("dbo.Counslers", "CounslerId", "dbo.Cabins", "CabinId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Counslers", "CounslerId", "dbo.Cabins");
            DropIndex("dbo.Counslers", new[] { "CounslerId" });
            DropPrimaryKey("dbo.Counslers");
            AlterColumn("dbo.Counslers", "CounslerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Counslers", "CounslerId");
        }
    }
}

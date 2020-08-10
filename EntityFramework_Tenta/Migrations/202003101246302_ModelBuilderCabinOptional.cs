namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelBuilderCabinOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Counslers", "CounslerId", "dbo.Cabins");
            DropIndex("dbo.Counslers", new[] { "CounslerId" });
            DropPrimaryKey("dbo.Counslers");
            AddColumn("dbo.Counslers", "CabinId", c => c.Int());
            AlterColumn("dbo.Counslers", "CounslerId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Counslers", "CounslerId");
            CreateIndex("dbo.Counslers", "CabinId");
            AddForeignKey("dbo.Counslers", "CabinId", "dbo.Cabins", "CabinId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Counslers", "CabinId", "dbo.Cabins");
            DropIndex("dbo.Counslers", new[] { "CabinId" });
            DropPrimaryKey("dbo.Counslers");
            AlterColumn("dbo.Counslers", "CounslerId", c => c.Int(nullable: false));
            DropColumn("dbo.Counslers", "CabinId");
            AddPrimaryKey("dbo.Counslers", "CounslerId");
            CreateIndex("dbo.Counslers", "CounslerId");
            AddForeignKey("dbo.Counslers", "CounslerId", "dbo.Cabins", "CabinId");
        }
    }
}

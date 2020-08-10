namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cabins",
                c => new
                    {
                        CabinId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CabinId);
            
            CreateTable(
                "dbo.Campers",
                c => new
                    {
                        CamperId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Phonenumber = c.Int(nullable: false),
                        Cabin_CabinId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CamperId)
                .ForeignKey("dbo.Cabins", t => t.Cabin_CabinId, cascadeDelete: true)
                .Index(t => t.Cabin_CabinId);
            
            CreateTable(
                "dbo.Relations",
                c => new
                    {
                        RelationId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Camper_CamperId = c.Int(),
                    })
                .PrimaryKey(t => t.RelationId)
                .ForeignKey("dbo.Campers", t => t.Camper_CamperId)
                .Index(t => t.Camper_CamperId);
            
            CreateTable(
                "dbo.Counslers",
                c => new
                    {
                        CounslerId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Phonenumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CounslerId);
            
            CreateTable(
                "dbo.NextOfKins",
                c => new
                    {
                        NextOfKinId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Phonenumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NextOfKinId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relations", "Camper_CamperId", "dbo.Campers");
            DropForeignKey("dbo.Campers", "Cabin_CabinId", "dbo.Cabins");
            DropIndex("dbo.Relations", new[] { "Camper_CamperId" });
            DropIndex("dbo.Campers", new[] { "Cabin_CabinId" });
            DropTable("dbo.NextOfKins");
            DropTable("dbo.Counslers");
            DropTable("dbo.Relations");
            DropTable("dbo.Campers");
            DropTable("dbo.Cabins");
        }
    }
}

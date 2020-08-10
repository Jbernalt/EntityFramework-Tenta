namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camperstoreprocedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Camper_Insert",
                p => new
                    {
                        Firstname = p.String(),
                        Lastname = p.String(),
                        Phonenumber = p.Int(),
                        Cabin_CabinId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Campers]([Firstname], [Lastname], [Phonenumber], [Cabin_CabinId])
                      VALUES (@Firstname, @Lastname, @Phonenumber, @Cabin_CabinId)
                      
                      DECLARE @CamperId int
                      SELECT @CamperId = [CamperId]
                      FROM [dbo].[Campers]
                      WHERE @@ROWCOUNT > 0 AND [CamperId] = scope_identity()
                      
                      SELECT t0.[CamperId]
                      FROM [dbo].[Campers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[CamperId] = @CamperId"
            );
            
            CreateStoredProcedure(
                "dbo.Camper_Update",
                p => new
                    {
                        CamperId = p.Int(),
                        Firstname = p.String(),
                        Lastname = p.String(),
                        Phonenumber = p.Int(),
                        Cabin_CabinId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Campers]
                      SET [Firstname] = @Firstname, [Lastname] = @Lastname, [Phonenumber] = @Phonenumber, [Cabin_CabinId] = @Cabin_CabinId
                      WHERE (([CamperId] = @CamperId) AND ([Cabin_CabinId] = @Cabin_CabinId))"
            );
            
            CreateStoredProcedure(
                "dbo.Camper_Delete",
                p => new
                    {
                        CamperId = p.Int(),
                        Cabin_CabinId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Campers]
                      WHERE (([CamperId] = @CamperId) AND ([Cabin_CabinId] = @Cabin_CabinId))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Camper_Delete");
            DropStoredProcedure("dbo.Camper_Update");
            DropStoredProcedure("dbo.Camper_Insert");
        }
    }
}

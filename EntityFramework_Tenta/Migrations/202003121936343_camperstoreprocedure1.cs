namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camperstoreprocedure1 : DbMigration
    {
        public override void Up()
        {
            RenameStoredProcedure(name: "dbo.Camper_Insert", newName: "sp_InsertCamper");
            RenameStoredProcedure(name: "dbo.Camper_Update", newName: "sp_UpdateCamper");
            RenameStoredProcedure(name: "dbo.Camper_Delete", newName: "sp_DeleteCamper");
            AlterStoredProcedure(
                "dbo.sp_InsertCamper",
                p => new
                    {
                        FirstName = p.String(),
                        LastName = p.String(),
                        Phone = p.Int(),
                        Cabin_CabinId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Campers]([Firstname], [Lastname], [Phonenumber], [Cabin_CabinId])
                      VALUES (@FirstName, @LastName, @Phone, @Cabin_CabinId)
                      
                      DECLARE @CamperId int
                      SELECT @CamperId = [CamperId]
                      FROM [dbo].[Campers]
                      WHERE @@ROWCOUNT > 0 AND [CamperId] = scope_identity()
                      
                      SELECT t0.[CamperId] AS Id
                      FROM [dbo].[Campers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[CamperId] = @CamperId"
            );
            
            AlterStoredProcedure(
                "dbo.sp_UpdateCamper",
                p => new
                    {
                        CamperId = p.Int(),
                        FirstName = p.String(),
                        LastName = p.String(),
                        Phone = p.Int(),
                        Cabin_CabinId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Campers]
                      SET [Firstname] = @FirstName, [Lastname] = @LastName, [Phonenumber] = @Phone, [Cabin_CabinId] = @Cabin_CabinId
                      WHERE (([CamperId] = @CamperId) AND ([Cabin_CabinId] = @Cabin_CabinId))"
            );
            
            AlterStoredProcedure(
                "dbo.sp_DeleteCamper",
                p => new
                    {
                        Id = p.Int(),
                        Cabin_CabinId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Campers]
                      WHERE (([CamperId] = @Id) AND ([Cabin_CabinId] = @Cabin_CabinId))"
            );
            
        }
        
        public override void Down()
        {
            RenameStoredProcedure(name: "dbo.sp_DeleteCamper", newName: "Camper_Delete");
            RenameStoredProcedure(name: "dbo.sp_UpdateCamper", newName: "Camper_Update");
            RenameStoredProcedure(name: "dbo.sp_InsertCamper", newName: "Camper_Insert");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}

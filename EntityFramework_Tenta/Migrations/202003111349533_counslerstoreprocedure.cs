namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class counslerstoreprocedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Counsler_Insert",
                p => new
                    {
                        Firstname = p.String(),
                        Lastname = p.String(),
                        Phonenumber = p.Int(),
                        CabinId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Counslers]([Firstname], [Lastname], [Phonenumber], [CabinId])
                      VALUES (@Firstname, @Lastname, @Phonenumber, @CabinId)
                      
                      DECLARE @CounslerId int
                      SELECT @CounslerId = [CounslerId]
                      FROM [dbo].[Counslers]
                      WHERE @@ROWCOUNT > 0 AND [CounslerId] = scope_identity()
                      
                      SELECT t0.[CounslerId]
                      FROM [dbo].[Counslers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[CounslerId] = @CounslerId"
            );
            
            CreateStoredProcedure(
                "dbo.Counsler_Update",
                p => new
                    {
                        CounslerId = p.Int(),
                        Firstname = p.String(),
                        Lastname = p.String(),
                        Phonenumber = p.Int(),
                        CabinId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Counslers]
                      SET [Firstname] = @Firstname, [Lastname] = @Lastname, [Phonenumber] = @Phonenumber, [CabinId] = @CabinId
                      WHERE ([CounslerId] = @CounslerId)"
            );
            
            CreateStoredProcedure(
                "dbo.Counsler_Delete",
                p => new
                    {
                        CounslerId = p.Int(),
                        CabinId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Counslers]
                      WHERE (([CounslerId] = @CounslerId) AND (([CabinId] = @CabinId) OR ([CabinId] IS NULL AND @CabinId IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Counsler_Delete");
            DropStoredProcedure("dbo.Counsler_Update");
            DropStoredProcedure("dbo.Counsler_Insert");
        }
    }
}

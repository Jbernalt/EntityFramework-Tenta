namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cabinstoreprocedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Cabin_Insert",
                p => new
                    {
                        Name = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Cabins]([Name])
                      VALUES (@Name)
                      
                      DECLARE @CabinId int
                      SELECT @CabinId = [CabinId]
                      FROM [dbo].[Cabins]
                      WHERE @@ROWCOUNT > 0 AND [CabinId] = scope_identity()
                      
                      SELECT t0.[CabinId]
                      FROM [dbo].[Cabins] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[CabinId] = @CabinId"
            );
            
            CreateStoredProcedure(
                "dbo.Cabin_Update",
                p => new
                    {
                        CabinId = p.Int(),
                        Name = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Cabins]
                      SET [Name] = @Name
                      WHERE ([CabinId] = @CabinId)"
            );
            
            CreateStoredProcedure(
                "dbo.Cabin_Delete",
                p => new
                    {
                        CabinId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Cabins]
                      WHERE ([CabinId] = @CabinId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Cabin_Delete");
            DropStoredProcedure("dbo.Cabin_Update");
            DropStoredProcedure("dbo.Cabin_Insert");
        }
    }
}

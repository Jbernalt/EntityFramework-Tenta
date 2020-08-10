namespace EntityFramework_Tenta.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class storeprocedurenextofkin : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.sp_InsertNextOfKin",
                p => new
                    {
                        FirstName = p.String(),
                        LastName = p.String(),
                        Phone = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[NextOfKins]([Firstname], [Lastname], [Phonenumber])
                      VALUES (@FirstName, @LastName, @Phone)
                      
                      DECLARE @NextOfKinId int
                      SELECT @NextOfKinId = [NextOfKinId]
                      FROM [dbo].[NextOfKins]
                      WHERE @@ROWCOUNT > 0 AND [NextOfKinId] = scope_identity()
                      
                      SELECT t0.[NextOfKinId] AS Id
                      FROM [dbo].[NextOfKins] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[NextOfKinId] = @NextOfKinId"
            );
            
            CreateStoredProcedure(
                "dbo.sp_UpdateNextOfKin",
                p => new
                    {
                        NextOfKinId = p.Int(),
                        FirstName = p.String(),
                        LastName = p.String(),
                        Phone = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[NextOfKins]
                      SET [Firstname] = @FirstName, [Lastname] = @LastName, [Phonenumber] = @Phone
                      WHERE ([NextOfKinId] = @NextOfKinId)"
            );
            
            CreateStoredProcedure(
                "dbo.sp_DeleteNextOfKin",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[NextOfKins]
                      WHERE ([NextOfKinId] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.sp_DeleteNextOfKin");
            DropStoredProcedure("dbo.sp_UpdateNextOfKin");
            DropStoredProcedure("dbo.sp_InsertNextOfKin");
        }
    }
}

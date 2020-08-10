using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Tenta
{
    public class CampContext : DbContext
    {
        public DbSet<NextOfKin> NextOfKins { get; set; }
        public DbSet<Camper> Campers { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Counsler> Counslers { get; set; }
        public DbSet<Relation> Relations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabin>()
                        .MapToStoredProcedures();

            modelBuilder.Entity<Camper>()
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertCamper").Parameter(pm => pm.Firstname, "FirstName")
                .Parameter(pm => pm.Lastname, "LastName").Parameter(pm => pm.Phonenumber, "Phone").Result(rs => rs.CamperId, "Id"))
                
                .Update(sp => sp.HasName("sp_UpdateCamper").Parameter(pm => pm.Firstname, "FirstName")
                .Parameter(pm => pm.Lastname, "LastName").Parameter(pm => pm.Phonenumber, "Phone"))
                
                .Delete(sp => sp.HasName("sp_DeleteCamper").Parameter(pm => pm.CamperId, "Id")));

            modelBuilder.Entity<Counsler>()
                        .MapToStoredProcedures();

            modelBuilder.Entity<NextOfKin>()
                .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertNextOfKin").Parameter(pm => pm.Firstname, "FirstName")
                .Parameter(pm => pm.Lastname, "LastName").Parameter(pm => pm.Phonenumber, "Phone").Result(rs => rs.NextOfKinId, "Id"))
                
                .Update(sp => sp.HasName("sp_UpdateNextOfKin").Parameter(pm => pm.Firstname, "FirstName")
                .Parameter(pm => pm.Lastname, "LastName").Parameter(pm => pm.Phonenumber, "Phone"))
                
                .Delete(sp => sp.HasName("sp_DeleteNextOfKin").Parameter(pm => pm.NextOfKinId, "Id")));


            modelBuilder.Entity<Counsler>()
                     .HasOptional(s => s.Cabin)
                     .WithOptionalDependent(s => s.Counsler)
                     .Map(s => s.MapKey("CabinId"));
        }
    }
}

using System.Reflection;
using DB.Entities;
using Microsoft.EntityFrameworkCore;


namespace DB.context
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<OwnerEntity> Owner { get; set; }
        public DbSet<VehicleEntity> Vehicle { get; set; }
        public DbSet<OwnerVehicleEntity> OwnerVehicle { get; set; }
        public DbSet<SaleEntity> Sale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
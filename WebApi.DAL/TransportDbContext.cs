using Microsoft.EntityFrameworkCore;
using WebApi.DAL.Models;

namespace WebApi.DAL
{
    public class TransportDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<VehicleOwner> VehicleOwner { get; set; }

        public TransportDbContext(DbContextOptions<TransportDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TransportDbContext).Assembly);

            DataSeeder.Seed(modelBuilder);
        }
    }
}

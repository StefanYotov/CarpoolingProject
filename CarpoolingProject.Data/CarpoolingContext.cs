using CarpoolingProject.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
namespace CarpoolingProject.Data
{
    public class CarpoolingContext : DbContext, ICarpoolingContext
    {
        public CarpoolingContext()
        {

        }
        public CarpoolingContext(DbContextOptions<CarpoolingContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Travel> Travels { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<TravelApplication> TravelApplications { get; set; }
        public virtual DbSet<TravelPassenger> TravelPassengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Seed();
        }
    }
}
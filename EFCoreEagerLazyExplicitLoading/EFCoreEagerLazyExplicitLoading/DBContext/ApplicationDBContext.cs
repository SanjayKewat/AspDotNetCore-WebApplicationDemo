using EFCoreEagerLazyExplicitLoading.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEagerLazyExplicitLoading.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaAmenity> VillaAmenities { get; set; }

        //Seeding some value
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //insert some data using hasDataMethod
            modelBuilder.Entity<Villa>().HasData(
                new Villa
                {
                    Id = 1,
                    Name = "Royal Villa",
                    Price = 200
                },
                new Villa
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    Price = 300
                },
                new Villa
                {
                    Id = 3,
                    Name = "Luxuary Pool Villa",
                    Price = 400
                }
                );

            modelBuilder.Entity<VillaAmenity>().HasData(
                new VillaAmenity
                {
                    Id = 1,
                    VillaId = 1,
                    Name = "Private Villa 1"
                },
                new VillaAmenity
                {
                    Id = 2,
                    VillaId = 1,
                    Name = "Private Villa 2"
                },
                new VillaAmenity
                {
                    Id = 3,
                    VillaId = 1,
                    Name = "Private Villa 3"
                },
                new VillaAmenity
                {
                    Id = 4,
                    VillaId = 2,
                    Name = "Premium Villa 2"
                },
                new VillaAmenity
                {
                    Id = 5,
                    VillaId = 2,
                    Name = "Premium Villa 3"
                },
                new VillaAmenity
                {
                    Id = 6,
                    VillaId = 3,
                    Name = "Private Luxuary Villa 3"
                },
                new VillaAmenity
                {
                    Id = 7,
                    VillaId = 3,
                    Name = "Premium Luxuary Villa 2"
                },
                new VillaAmenity
                {
                    Id = 8,
                    VillaId = 3,
                    Name = "Premium Luxuary Villa 3"
                }
                );
        }
    }
}

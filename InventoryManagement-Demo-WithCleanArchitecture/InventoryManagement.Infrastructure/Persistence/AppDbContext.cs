using InventoryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Persistence
{
    /// <summary>
    /// Application database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<EquipmentInventory> EquipmentInventories { get; set; }
        public DbSet<ItemGroup> ItemGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EquipmentInventory>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ItemCode).HasMaxLength(10).IsRequired();
                entity.Property(e => e.ItemName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Make).HasMaxLength(50).IsRequired();
                entity.Property(e => e.ItemModel).HasMaxLength(50);
                entity.Property(e => e.TrackingMethod).HasMaxLength(250);
                entity.Property(e => e.IsVoid).IsRequired();

                entity.HasOne(e => e.ItemGroup)
                      .WithMany()
                      .HasForeignKey(e => e.ItemGroupId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ItemGroup>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ItemGroupName).HasMaxLength(50).IsRequired();
                entity.Property(e => e.IsVoid).IsRequired();
            });



            modelBuilder.Entity<ItemGroup>().HasData(
            new ItemGroup
            {
                Id = 1,
                ItemGroupName = "Cylindrical Grinding- HMT",
                IsVoid = false
            },
             new ItemGroup
             {
                 Id = 2,
                 ItemGroupName = "EDM Machine- GF",
                 IsVoid = false
             });

            base.OnModelCreating(modelBuilder);
        }
    }
}
﻿using CleanMovie.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many (Member & Rentals)
            modelBuilder.Entity<Member>()
                .HasOne<Rental>(s => s.Rental)
                .WithMany(r => r.Members)
                .HasForeignKey(s => s.RentalId);

            //Many to Many (Rental & Movie)
            modelBuilder.Entity<MovieRental>()
                .HasKey(s => new { s.RentalId, s.MovieId });

            //handle Decimals to avoid precision loss
            modelBuilder.Entity<Rental>()
                .Property(s => s.TotalCost)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Movie>()
               .Property(s => s.RentalCost)
               .HasColumnType("decimal(18,2)");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MovieRental> MovieRentals { get;}
    }
}

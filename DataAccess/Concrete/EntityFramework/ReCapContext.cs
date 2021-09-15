using Core.Entities.Entity;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context :Db tabloları ile proje tablolarını bağlamak.
    public class ReCapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-97A2EM3\SQLEXPRESS;Database=ReCapProjectDb;Trusted_Connection=true");


        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Payment> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Brand>().ToTable("Brands");
            modelBuilder.Entity<Customer>()
           .HasKey(p => p.UserId);
            modelBuilder.Entity<CreditCard>()
          .HasKey(p => p.CreditCartId);
            modelBuilder.Entity<Color>().Property(p => p.ColorId).HasColumnName("ColorsId");
            //  modelBuilder.Entity<Brand>().Property(p => p.BrandName).HasColumnName("Name");
        }
    }
}

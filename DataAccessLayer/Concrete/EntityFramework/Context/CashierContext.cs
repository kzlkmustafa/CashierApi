﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework.Context
{
    public class CashierContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\mssqllocaldb;Database=CashierAppDb;Trusted_Connection=true");
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketDetail> BasketDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Kdv> Kdvs { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasOne(x => x.Kdv)
                .WithMany(y => y.Products)
                .HasForeignKey(z => z.KdvId);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(y => y.Products)
                .HasForeignKey(z => z.CategoryId);

            modelBuilder.Entity<BasketDetail>()
                .HasOne(x => x.Basket)
                .WithMany(y => y.BasketDetails)
                .HasForeignKey(z => z.BasketId);

            modelBuilder.Entity<BasketDetail>()
                .HasOne(x => x.Product)
                .WithMany(y => y.BasketDetails)
                .HasForeignKey(z => z.ProductId);

            modelBuilder.Entity<Basket>()
                .HasOne(x => x.AppUser)
                .WithMany(y => y.Baskets)
                .HasForeignKey(z => z.AppUserId);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne(x => x.AppUser)
                .WithMany(y => y.UserOperationClaims)
                .HasForeignKey(z => z.AppUserId);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne(x => x.OperationClaim)
                .WithMany(y => y.UserOperationClaims)
                .HasForeignKey(z => z.OperationClaimId);

            modelBuilder.Entity<AppUser>(x =>
            {
                x.Property(y => y.UserName)
                .HasMaxLength(50)
                .IsRequired(true);

                x.Property(y => y.NameSurname)
                .HasMaxLength(100);

                x.Property(y => y.PasswordHash)
                .IsRequired(true);
                
                x.Property(y => y.PasswordSalt)
                .IsRequired(true);


                x.Property(y => y.Email)
                .HasMaxLength(100)
                .IsRequired(true);

                x.Property(y => y.Gender)
                .HasMaxLength(1);

                x.Property(y => y.Telnr)
                .HasMaxLength(15);

            });

            modelBuilder.Entity<Product>(x =>
            {
                x.Property(y => y.ProductName)
                .HasMaxLength(100);
                x.Property(y => y.ProductDescription)
                .HasMaxLength(100);
            });
            modelBuilder.Entity<Category>()
                .Property(x => x.CategoryName)
                .HasMaxLength(100);
               
        }
    }
}

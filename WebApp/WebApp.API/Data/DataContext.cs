﻿using Microsoft.EntityFrameworkCore;
using WebApp.Shared.Entities;

namespace WebApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
        }
    }
}
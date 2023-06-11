using FarmFresh_API.Extensions;
using FarmFresh_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmFresh_API.Data
{
    public class FarmFreshDdContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public FarmFreshDdContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStock>().HasKey(k => new { k.ProductId, k.UnitId });
            modelBuilder.Seed();
        }
    }
}

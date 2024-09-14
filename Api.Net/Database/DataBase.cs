using Api.Net.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

namespace Api.Net.Database
{
    public class DataBase : DbContext
    {

        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<DesiredProduct> desiredProducts { get; set; }

        public DataBase(DbContextOptions<DataBase> options) : base(options) {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=dataapiproducts.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.category).WithMany(c => c.products).HasForeignKey(p => p.categoryId);

            modelBuilder.Entity<DesiredProduct>().HasOne(d => d.product).WithMany(p => p.desiredProducts).HasForeignKey(d => d.productId);

            modelBuilder.Entity<DesiredProduct>().HasOne(d => d.user).WithMany(u => u.desiredProducts).HasForeignKey(d => d.userId);
        }

    }
}

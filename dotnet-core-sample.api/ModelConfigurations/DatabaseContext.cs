using System;
using dotnet_core_sample.api.Enums;
using dotnet_core_sample.api.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_sample.api.ModelConfigurations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}

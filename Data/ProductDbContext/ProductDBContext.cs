﻿using Microsoft.EntityFrameworkCore;
using OKR.Common.Domain;
using OKR.Common.Persistence.Database.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKR.Common.Persistence.Database.ProductDbContext
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }

}

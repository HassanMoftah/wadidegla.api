using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wadidegla.DataLayer.Models;

namespace Wadidegla.DataLayer
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() { }
        public DbSet<TbCategory> TbCategories { get; set; }
        public DbSet<TbCategoryAttribute>  TbCategoryAttributes { get; set; }
        public DbSet<TbCategoryAttributeOption> TbCategoryAttributeOptions { get; set; }
        public DbSet<TbProduct> TbProducts { get; set; }
        public DbSet<TbProductImage> TbProductImages { get; set; }
        public DbSet<TbProductAttribute> TbProductAttributes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Data Source=HASSAN-MOFTAH-P;Initial Catalog=WadideglaDb;integrated security=true;Connect Timeout=50");
            }
        }

    }
}

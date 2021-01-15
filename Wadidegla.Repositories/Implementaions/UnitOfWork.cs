using System;
using System.Collections.Generic;
using System.Text;
using Wadidegla.DataLayer;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.Repositories.Implementaions
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            CategoryAttributes = new CategoryAttributeRepository(_context);
            CategoryAttributeOptions = new CategoryAttributeOptionRepository(_context);
            Products = new ProductRepository(_context);
            ProductImages = new ProductImageRepository(_context);
            ProductAttributes = new ProductAttributeRepository(_context);
        }

        public ICategoryRepository Categories { get; private set; }

        public ICategoryAttributeRepository CategoryAttributes { get; private set; }

        public ICategoryAttributeOptionRepository CategoryAttributeOptions { get; private set; }

        public IProductRepository Products { get; private set; }

        public IProductAttributeRepository ProductAttributes { get; private set; }

        public IProductImageRepository ProductImages { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wadidegla.DataLayer;
using Wadidegla.DataLayer.Models;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.Repositories.Implementaions
{
    class ProductImageRepository:Repository<TbProductImage>,IProductImageRepository
    {
        public ProductImageRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<TbProductImage> GetAllOfProduct(int id)
        {
            return Context.Set<TbProductImage>().Where(x => x.ProductId == id);
        }
        //extra work
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wadidegla.DataLayer;
using Wadidegla.DataLayer.Models;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.Repositories.Implementaions
{
    public class ProductAttributeRepository:Repository<TbProductAttribute>,IProductAttributeRepository
    {
        public ProductAttributeRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public TbProductAttribute GetEagerLoading(int id)
        {
            return Context.Set<TbProductAttribute>().Where(x => x.Id == id).Include(x => x.CategoryAttribute).SingleOrDefault();
        }

        public IEnumerable<TbProductAttribute> GetEagerLoadingOfProduct(int id)
        {
            return Context.Set<TbProductAttribute>().Where(x => x.ProductId== id).Include(x => x.CategoryAttribute);
        }
        //extra work
    }
}

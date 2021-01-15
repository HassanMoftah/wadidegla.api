using System;
using System.Collections.Generic;
using System.Text;
using Wadidegla.DataLayer;
using Wadidegla.DataLayer.Models;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.Repositories.Implementaions
{
    public class ProductRepository :Repository<TbProduct>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
        //extra work
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wadidegla.DataLayer;
using Wadidegla.DataLayer.Models;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.Repositories.Implementaions
{
    class CategoryAttributeRepository:Repository<TbCategoryAttribute> , ICategoryAttributeRepository
    {
        public CategoryAttributeRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<TbCategoryAttribute> GetAllOfCategory(int id)
        {
            return Context.Set<TbCategoryAttribute>().Where(x => x.CategoryId == id);
        }
    }
}

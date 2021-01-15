using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wadidegla.DataLayer;
using Wadidegla.DataLayer.Models;
using Wadidegla.Repositories.Interfaces;

namespace Wadidegla.Repositories.Implementaions
{
   public class CategoryAttributeOptionRepository:Repository<TbCategoryAttributeOption>, ICategoryAttributeOptionRepository
    {
        public CategoryAttributeOptionRepository(ApplicationDbContext context) : base(context) { }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<TbCategoryAttributeOption> GetAllOfCategoryAttribute(int id)
        {
            return Context.Set<TbCategoryAttributeOption>().Where(x => x.CategoryAttributeId == id);
        }
    }
}

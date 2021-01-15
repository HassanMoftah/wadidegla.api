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
    public class CategoryRepository :Repository<TbCategory>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context){ }
        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<TbCategory> GetAllFirstParents()
        {
            return Context.Set<TbCategory>().Where(x => x.ParentId == 0);
        }

        public IEnumerable<TbCategory> GetAllOfParent(int id)
        {
            return Context.Set<TbCategory>().Where(x => x.ParentId == id);
        }
        //extra work

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Wadidegla.DataLayer.Models;

namespace Wadidegla.Repositories.Interfaces
{
    public interface ICategoryAttributeRepository : IRepository<TbCategoryAttribute>
    {
        IEnumerable<TbCategoryAttribute> GetAllOfCategory(int id);
    }
}

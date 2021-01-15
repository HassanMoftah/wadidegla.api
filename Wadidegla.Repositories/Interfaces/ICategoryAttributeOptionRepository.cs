using System;
using System.Collections.Generic;
using System.Text;
using Wadidegla.DataLayer.Models;

namespace Wadidegla.Repositories.Interfaces
{
    public interface ICategoryAttributeOptionRepository:IRepository<TbCategoryAttributeOption>
    {
        IEnumerable<TbCategoryAttributeOption> GetAllOfCategoryAttribute(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Wadidegla.DataLayer.Models;

namespace Wadidegla.Repositories.Interfaces
{
    public interface IProductAttributeRepository:IRepository<TbProductAttribute>
    {
        TbProductAttribute GetEagerLoading(int id);
        IEnumerable<TbProductAttribute> GetEagerLoadingOfProduct(int id);
    }
}

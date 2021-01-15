using System;
using System.Collections.Generic;
using System.Text;
using Wadidegla.DataLayer.Models;

namespace Wadidegla.Repositories.Interfaces
{
    public interface IProductImageRepository:IRepository<TbProductImage>
    {
        IEnumerable<TbProductImage> GetAllOfProduct(int id);
    }
}

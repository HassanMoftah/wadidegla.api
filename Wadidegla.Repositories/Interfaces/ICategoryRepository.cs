using System;
using System.Collections.Generic;
using System.Text;
using Wadidegla.DataLayer.Models;

namespace Wadidegla.Repositories.Interfaces
{
    public interface ICategoryRepository:IRepository<TbCategory>
    {
        IEnumerable<TbCategory> GetAllFirstParents();
        IEnumerable<TbCategory> GetAllOfParent(int id);
        //customfunctions
    }
}

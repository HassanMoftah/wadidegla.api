using System;
using System.Collections.Generic;
using System.Text;

namespace Wadidegla.Repositories.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Categories { get; }
        ICategoryAttributeRepository CategoryAttributes { get; }
        ICategoryAttributeOptionRepository CategoryAttributeOptions { get; }
        IProductRepository Products { get; }
        IProductAttributeRepository ProductAttributes { get; }
        IProductImageRepository ProductImages { get; }
        int Complete();
    }
}

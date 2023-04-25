using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCrud.Models;

namespace ProductCrud.Services
{
    public interface IProductAttributeService
    {
        Task<IEnumerable<ProductAttribute>> GetProductAttributeById(int id);
        Task<ProductAttribute> CreateProductAttribute(ProductAttribute Product);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCrud.Models;

namespace ProductCrud.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsList();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product Product);
        Task UpdateProduct(Product Product);
        Task DeleteProduct(Product Product);
    }
}


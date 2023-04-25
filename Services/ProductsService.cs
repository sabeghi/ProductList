using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCrud.Data;
using ProductCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductCrud.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ProductDbContext _context;

        public ProductsService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsList()
        {
            return await _context.Products
                .Include(x => x.CategoryNavigation)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products
                .Include(x => x.CategoryNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> CreateProduct(Product Product)
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();
            return Product;
        }
        public async Task UpdateProduct(Product Product)
        {
            _context.Products.Update(Product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product Product)
        {
            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
        }
    }
}


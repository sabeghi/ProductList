using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCrud.Data;
using ProductCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductCrud.Services
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly ProductDbContext _context;

        public ProductAttributeService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductAttribute>> GetProductAttributeById(int id)
        {
            return await _context.ProductAttributes.Where(attr => attr.ProductId == id)
                .Include(x => x.IdNavigation)
                .ToListAsync();
        }

        public async Task<ProductAttribute> CreateProductAttribute(ProductAttribute ProductAttribute)
        {
            _context.ProductAttributes.Add(ProductAttribute);
            await _context.SaveChangesAsync();
            return ProductAttribute;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCrud.Data;
using ProductCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductCrud.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ProductDbContext _context;

        public CategoriesService(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesList()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}


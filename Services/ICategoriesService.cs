using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCrud.Models;

namespace ProductCrud.Services
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetCategoriesList();
    }
}

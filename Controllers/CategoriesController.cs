using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCrud.Models;
using ProductCrud.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProductCrud.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _Categoreiservice;

        public CategoriesController(ICategoriesService Categoreiservice)
        {
            _Categoreiservice = Categoreiservice;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _Categoreiservice.GetCategoriesList();
        }
    }
}

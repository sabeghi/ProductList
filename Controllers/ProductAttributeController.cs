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
    public class ProductAttributeController : ControllerBase
    {
        private readonly IProductAttributeService _ProductAttributeService;

        public ProductAttributeController(IProductAttributeService ProductAttributeService)
        {
            _ProductAttributeService = ProductAttributeService;
        }

        // GET: api/ProductAttribute/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<ProductAttribute>> Get(int id)
        {
            return await _ProductAttributeService.GetProductAttributeById(id);
        }

        // POST: api/ProductAttribute
        [HttpPost]
        public async Task<ActionResult<ProductAttribute>> Post(ProductAttribute ProductAttribute)
        {
            await _ProductAttributeService.CreateProductAttribute(ProductAttribute);

            return CreatedAtAction("Post", new { id = ProductAttribute.ProductId }, ProductAttribute);
        }
    }
}

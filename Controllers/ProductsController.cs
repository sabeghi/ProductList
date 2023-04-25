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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _ProductsService;

        public ProductsController(IProductsService ProductsService)
        {
            _ProductsService = ProductsService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _ProductsService.GetProductsList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var Product = await _ProductsService.GetProductById(id);

            if (Product == null)
            {
                return NotFound();
            }

            return Ok(Product);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product Product)
        {
            await _ProductsService.CreateProduct(Product);

            return CreatedAtAction("Post", new { id = Product.Id }, Product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest("Not a valid Product id");
            }

            await _ProductsService.UpdateProduct(Product);

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Product id");

            var Product = await _ProductsService.GetProductById(id);
            if (Product == null)
            {
                return NotFound();
            }

            await _ProductsService.DeleteProduct(Product);

            return NoContent();
        }
    }
}

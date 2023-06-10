using FarmFresh_API.Data;
using FarmFresh_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmFresh_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly FarmFreshDdContext _farmFreshDdContext;

        public ProductsController(FarmFreshDdContext farmFreshDdContext)
        {
            this._farmFreshDdContext = farmFreshDdContext;
        }

		[Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _farmFreshDdContext.Products.Include(x => x.Category).ToListAsync();
            return Ok(products);
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
		[Route("{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _farmFreshDdContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
			
			if(product == null)
			{
				return NotFound();
			}
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product productRequest)
        {
            await _farmFreshDdContext.Products.AddAsync(productRequest);
            await _farmFreshDdContext.SaveChangesAsync();

            return Ok(productRequest);
        }
		
		[HttpPut]
		[Route("{id:int}")]
		public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product productRequest)
		{
			var product = await _farmFreshDdContext.Products.FindAsync(id);
			
			if(product == null)
			{
				return NotFound();
			}
			
			product.Name = productRequest.Name;
			product.CategoryId = productRequest.CategoryId;
			product.Description = productRequest.Description;
			
			await _farmFreshDdContext.SaveChangesAsync();
			
			return Ok(product);
		}
		
		[HttpDelete]
		[Route("{id:int}")]
		public async Task<IActionResult> DeleteProduct([FromRoute] int id)
		{
			var product = await _farmFreshDdContext.Products.FindAsync(id);
			
			if(product == null)
			{
				return NotFound();
			}
			
			_farmFreshDdContext.Products.Remove(product);
			await _farmFreshDdContext.SaveChangesAsync();
			
			return Ok(product);
		}
    }
}

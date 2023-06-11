using FarmFresh_API.Data;
using FarmFresh_API.Helpers;
using FarmFresh_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        public async Task<IActionResult> GetAllProducts(int page = 1, int perPage = 10, string orderBy = "name", string direction = "asc", string search = "")
        {
            int position = (page - 1) * perPage;

            var products = from p in _farmFreshDdContext.Products
						   select p;

			if(!string.IsNullOrEmpty(search))
			{
				products = products.Where(x => x.Name.Contains(search));
			}
			
			int total = products.Count();

			if (orderBy.ToLower() == "id")
			{
				if (direction.ToLower() == "desc")
				{
					products = products.OrderByDescending(x => x.Id);
				}
				else { products = products.OrderBy(x => x.Id); }
			}
			else
			{
				if (direction.ToLower() == "desc")
				{
					products = products.OrderByDescending(x => x.Name);
				}
				else
				{
					products = products.OrderBy(x => x.Name);
				}
			}

			products = products.Skip(position)
				.Take(perPage)
				.Include(x => x.Category);

            return Ok(new { Products = await products.ToListAsync(), Total = total });
        }

        [Authorize(Policy = "Admin")]
        [HttpGet]
		[Route("{id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _farmFreshDdContext.Products.Include(x => x.Category).Include(x => x.Stocks).FirstOrDefaultAsync(x => x.Id == id);
			
			if(product == null)
			{
				return NotFound();
			}
            return Ok(product);
        }

		[Authorize(Policy = "Admin")]
		[HttpPost]
		public async Task<IActionResult> AddProduct([FromBody] Product productRequest)
		{
			//Insert sample data
			//For demostration purpose
			productRequest.Stocks = new List<ProductStock> { new ProductStock { UnitId = 1, Instock = 100, Price = 1000 } };
			
			await _farmFreshDdContext.Products.AddAsync(productRequest);
			await _farmFreshDdContext.SaveChangesAsync();
			

			return Ok(productRequest);
		}

        [Authorize(Policy = "Admin")]
        [HttpPut]
		[Route("{id:int}")]
		public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product productRequest, bool imageChanged)
		{
			var product = await _farmFreshDdContext.Products.FindAsync(id);
			
			if(product == null)
			{
				return NotFound();
			}
			
			product.Name = productRequest.Name;
			product.CategoryId = productRequest.CategoryId;
			product.Description = productRequest.Description;
			product.CountryOfOrigin = productRequest.CountryOfOrigin;
			if(imageChanged)
			{
				product.Images = productRequest.Images;
			}

			await _farmFreshDdContext.SaveChangesAsync();
			
			return Ok(product);
		}

        [Authorize(Policy = "Admin")]
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

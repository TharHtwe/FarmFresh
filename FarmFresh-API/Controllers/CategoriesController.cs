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
    public class CategoriesController : Controller
    {
        private readonly FarmFreshDdContext _farmFreshDdContext;

        public CategoriesController(FarmFreshDdContext farmFreshDdContext)
        {
            this._farmFreshDdContext = farmFreshDdContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _farmFreshDdContext.Categories.ToListAsync();
            return Ok(categories);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category categoryRequest)
        {
            await _farmFreshDdContext.Categories.AddAsync(categoryRequest);
            await _farmFreshDdContext.SaveChangesAsync();

            return Ok(categoryRequest);
        }
    }
}

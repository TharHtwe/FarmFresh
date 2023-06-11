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
    public class UnitsController : Controller
    {
        private readonly FarmFreshDdContext _farmFreshDdContext;

        public UnitsController(FarmFreshDdContext farmFreshDdContext)
        {
            this._farmFreshDdContext = farmFreshDdContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUnits()
        {
            var units = await _farmFreshDdContext.Units.ToListAsync();
            return Ok(units);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddUnit([FromBody] Unit unitRequest)
        {
            await _farmFreshDdContext.Units.AddAsync(unitRequest);
            await _farmFreshDdContext.SaveChangesAsync();

            return Ok(unitRequest);
        }
    }
}

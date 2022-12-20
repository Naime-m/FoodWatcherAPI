using FoodWatcherAPI.Data;
using FoodWatcherAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodWatcherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodDbContext _context;

        public FoodController(FoodDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Food>> Get()
        {
            return await _context.Foods.ToListAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Food), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var food =  await _context.Foods.FindAsync(id);
            return food == null ? NotFound() : Ok(food);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = food.Id }, food);
        }

  

    }
}

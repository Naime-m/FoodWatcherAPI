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
            food.Added = DateTime.Now;
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = food.Id }, food);
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> Update(int id, Food food)
        {
            if (id != food.Id)
                return BadRequest();

            _context.Entry(food).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var foodToDelete = await _context.Foods.FindAsync(id);
            if (foodToDelete == null)
                return NotFound();

            _context.Foods.Remove(foodToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

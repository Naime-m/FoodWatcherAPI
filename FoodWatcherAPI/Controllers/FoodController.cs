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
    }
}

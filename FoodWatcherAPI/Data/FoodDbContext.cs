using FoodWatcherAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodWatcherAPI.Data;

public class FoodDbContext : DbContext
{
    public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options)
    { }

    public DbSet<Food> Foods { get; set; }

}

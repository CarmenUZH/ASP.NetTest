using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurant { get; set; } //DbSet so that i not only query but also insert update and delete from database
        //Can have dozens of Entities
    }
}

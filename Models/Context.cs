using Microsoft.EntityFrameworkCore;
namespace ChefNDish.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Chef> Chefs { get; set; }
    }
}
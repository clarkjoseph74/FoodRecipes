
using FoodRecipes.Models;

namespace FoodRecipes.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Food> Foods { get; set; }
    public DbSet<Category>  Categories { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Fruits" },
            new Category { Id = 2, Name = "Vegetables" },
            new Category { Id = 3, Name = "Dairy Products" },
            new Category { Id = 4, Name = "Meat and Poultry" },
            new Category { Id = 5, Name = "Bakery and Cereals" }
        );
        base.OnModelCreating(modelBuilder);
    }
}

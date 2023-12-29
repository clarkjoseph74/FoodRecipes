namespace FoodRecipes.Models;

public class Category : BaseEntity
{
    public ICollection<Food> Foods { get; set; } = new List<Food>();
}

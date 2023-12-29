namespace FoodRecipes.Models;

public class Food : BaseEntity
{
    [MaxLength(3000)]
    public string Recipe { get; set; }
    public string Image { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}

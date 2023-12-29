using System.ComponentModel.DataAnnotations;

namespace FoodRecipes.Models;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(150)]
    public string Name { get; set; }
}

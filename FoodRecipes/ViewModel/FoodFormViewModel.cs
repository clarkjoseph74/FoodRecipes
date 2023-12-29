namespace FoodRecipes.ViewModel;

public class FoodFormViewModel
{
    [MaxLength(150)]
    public string Name { get; set; }

    [MaxLength(3000)]
    public string Recipe { get; set; }
    public int CategoryId { get; set; }
    public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
}

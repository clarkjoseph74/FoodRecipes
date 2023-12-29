using FoodRecipes.Attributes;
using FoodRecipes.Settings;

namespace FoodRecipes.ViewModel;

public class UpdateFoodViewModel : FoodFormViewModel
{
    [Required]
    public int Id { get; set; }

    public string? CurrentImage { get; set; }
    [AllowedExtensions(FileSettings.ALLOWED_EXTENSIONS), MaxFileSize(FileSettings.ALLOWED_MAX_SIZE_BYTE)]
    public IFormFile? Image { get; set; } = default!;

}

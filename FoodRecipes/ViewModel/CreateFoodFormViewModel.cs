

using FoodRecipes.Attributes;
using FoodRecipes.Settings;

namespace FoodRecipes.ViewModel;

public class CreateFoodFormViewModel : FoodFormViewModel
{
    [AllowedExtensions(FileSettings.ALLOWED_EXTENSIONS), MaxFileSize(FileSettings.ALLOWED_MAX_SIZE_BYTE)]
    public IFormFile Image { get; set; } = default!;
}

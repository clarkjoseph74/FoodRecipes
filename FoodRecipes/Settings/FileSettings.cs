namespace FoodRecipes.Settings;

public class FileSettings
{
    public const string IMAGE_PATH = "/assets/images/foods";
    public const string ALLOWED_EXTENSIONS = ".jpeg,.jpg,.png";
    public const int ALLOWED_MAX_SIZE_MB = 1;
    public const int ALLOWED_MAX_SIZE_BYTE = ALLOWED_MAX_SIZE_MB * 1024 * 1024 ;

}

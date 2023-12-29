namespace FoodRecipes.Attributes;

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string _allowedExtensions;
    public AllowedExtensionsAttribute(string allowedExtensions)
    {
        _allowedExtensions = allowedExtensions;
    }

    protected override ValidationResult? IsValid(object? value,
        ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file is not null)
        {
            var fileExtention = Path.GetExtension(file.FileName);
            var isAllowed = _allowedExtensions.Split(',').Contains(fileExtention , StringComparer.OrdinalIgnoreCase);
            if(!isAllowed )
            {
                return new ValidationResult($"Only {_allowedExtensions} is allowed!");
            }
        }
        return ValidationResult.Success;

    }
}

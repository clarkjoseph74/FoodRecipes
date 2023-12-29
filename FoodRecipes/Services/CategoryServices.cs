
namespace FoodRecipes.Services;

public class CategoryServices : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryServices(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<SelectListItem> GetSelectListItems()
    {
        return _context.Categories
            .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
            .OrderBy(c => c.Text)
            .AsNoTracking()
            .ToList();
    }
}

using FoodRecipes.Settings;

namespace FoodRecipes.Services;

public class FoodService : IFoodService
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string _imagesPath;
    public FoodService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
        _imagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.IMAGE_PATH}";
    }

    public IEnumerable<Food> GetAll()
    {
        return _context.Foods.Include(f => f.Category).AsNoTracking().ToList();
    }
    public Food? GetById(int id)
    {
        return _context.Foods.Include(f => f.Category).AsNoTracking().SingleOrDefault(f => f.Id == id);
    }

    public async Task Create(CreateFoodFormViewModel model)
    {

        var imageName = await SaveImage(model.Image);
        Food food = new()
        {
            Name = model.Name,
            Recipe = model.Recipe,
            CategoryId = model.CategoryId,
            Image = imageName
        };
        _context.Add(food);
        _context.SaveChanges();
    }

    public async Task<Food?> Update(UpdateFoodViewModel model)
    {
        var food = _context.Foods.Find(model.Id);
        if (food is null)
            return null;
        food.Name = model.Name;
        food.Recipe = model.Recipe;
        food.CategoryId = model.CategoryId;
        var hasNewImage = model.Image is not null;
        var oldImage = food.Image;
        if (hasNewImage)
        {
            food.Image = await SaveImage(model.Image!);
        }
        var effectedRows = _context.SaveChanges();
        if (effectedRows > 0)
        {
            if (hasNewImage)
            {
                var image = Path.Combine(_imagesPath, oldImage);
                File.Delete(image);
            }
            return food;

        }
        else
        {
            var image = Path.Combine(_imagesPath, food.Image);
            File.Delete(image);
            return null;


        }
    }
    public bool Delete(int id)
    {
        var isDeleted = false;

        var food = _context.Foods.Find(id);
        if (food is null)
            return isDeleted;
        _context.Foods.Remove(food);
        var effectedRows = _context.SaveChanges();
        if (effectedRows > 0)
        {
            isDeleted = true;
            var image = Path.Combine(_imagesPath, food.Image);
            File.Delete(image);
        }

        return isDeleted;
    }

    private async Task<string> SaveImage(IFormFile image)
    {
        var imageName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
        var path = Path.Combine(_imagesPath, imageName);
        using var stream = File.Create(path);
        await image.CopyToAsync(stream);
        return imageName;
    }

}

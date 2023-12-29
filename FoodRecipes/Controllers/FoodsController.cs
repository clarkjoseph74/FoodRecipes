using Microsoft.AspNetCore.Mvc;

namespace FoodRecipes.Controllers;
public class FoodsController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly IFoodService _foodService;

    public FoodsController(ICategoryService categoryService, IFoodService foodService)
    {
        _categoryService = categoryService;
        _foodService = foodService;
    }
    public IActionResult Index()
    {
        var foodRecipes = _foodService.GetAll();
        return View(foodRecipes);
    }

    public IActionResult Details(int id)
    {
        var food = _foodService.GetById(id);
        if (food is null)
        {
            return NotFound();
        }
        return View(food);
    }
    [HttpGet]
    public IActionResult Create()
    {
        CreateFoodFormViewModel viewModel = new()
        {
            Categories = _categoryService.GetSelectListItems()
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateFoodFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        await _foodService.Create(model);
        //return to the index
        return RedirectToAction(nameof(Index));
    }
    public IActionResult Update(int id)
    {
        var food = _foodService.GetById(id);
        if (food is null)
        {
            return NotFound();
        }

        UpdateFoodViewModel viewModel = new()
        {
            Id = food.Id,
            Categories = _categoryService.GetSelectListItems(),
            CategoryId = id,
            Name = food.Name,
            Recipe = food.Recipe,
            CurrentImage = food.Image
        };
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(UpdateFoodViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var food = await _foodService.Update(model);
        if (food is null)
        {
            return BadRequest();
        }
        //return to the index
        return RedirectToAction(nameof(Index));
    }
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        var isDeleted = _foodService.Delete(id);

        return isDeleted ? Ok() : BadRequest();
    }
}

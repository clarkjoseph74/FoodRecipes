using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodRecipes.Controllers;
public class HomeController : Controller
{
    private readonly IFoodService _foodService;

    public HomeController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    public IActionResult Index()
    {
        var foodRecipes = _foodService.GetAll();
        return View(foodRecipes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}

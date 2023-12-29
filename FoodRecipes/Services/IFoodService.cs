namespace FoodRecipes.Services;

public interface IFoodService
{

    IEnumerable<Food> GetAll();
    Food? GetById(int id);
    Task Create(CreateFoodFormViewModel model);

    Task<Food?> Update(UpdateFoodViewModel model);
    bool Delete(int id);

}

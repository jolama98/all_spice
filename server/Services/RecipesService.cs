
namespace all_spice.Services;

public class RecipeService
{
    private readonly RecipesRepository _repository;

    public RecipeService(RecipesRepository repository)
    {
        _repository = repository;
    }

    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }
}
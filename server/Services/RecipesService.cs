


namespace all_spice.Services;

public class RecipeService
{
    private readonly RecipesRepository _repository;

    public RecipeService(RecipesRepository repository)
    {
        _repository = repository;
    }

    public Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = _repository.CreateRecipe(recipeData);
        return recipe;
    }

    public List<Recipe> GetAllRecipes()
    {
        List<Recipe> recipes = _repository.GetAllRecipes();
        return recipes;
    }

    internal Recipe GetAllRecipesById(int recipeId)
    {
        Recipe recipe = _repository.GetAllRecipesById(recipeId);

        return recipe;
    }
}
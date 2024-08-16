



namespace all_spice.Services;

public class IngredientsService
{
    private readonly IngredientsRepository _ingredientsRepository;

    public IngredientsService(IngredientsRepository ingredientsRepository)
    {
        _ingredientsRepository = ingredientsRepository;
    }

    internal Ingredients CreateIngredient(Ingredients ingredientData, Account userInfo)
    {
        Ingredients ingredients = _ingredientsRepository.CreateIngredient(ingredientData, userInfo);
        return ingredients;
    }

    internal string DestroyIngredient(int ingredientsId, string userId)
    {





        _ingredientsRepository.DestroyIngredient(ingredientsId);
        return "Ingredient Deleted";
    }



    internal List<Ingredients> GetIngredientsForRecipe(int recipeId)
    {
        List<Ingredients> ingredients = _ingredientsRepository.GetIngredientsForRecipe(recipeId);
        return ingredients;
    }
}
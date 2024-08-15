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

    public string DestroyRecipe(int recipeId, string userId)
    {
        Recipe recipe = GetAllRecipesById(recipeId);

        if (recipe.CreatorId != userId)
        {
            throw new Exception("NO YOU CANNOT DELETE A PICTURE THAT YOU DID NOT CREATE");
        }

        _repository.DeleteRecipe(recipeId);
        return "Recipe was deleted";
    }


    public Recipe GetAllRecipesById(int recipeId)
    {
        Recipe recipe = _repository.GetAllRecipesById(recipeId);
        if(recipe == null)
        {
            throw new Exception($"NO NO NO recipe was found with the id of {recipeId}");
        }
        return recipe;
    }

    internal Recipe UpdateRecipe(int recipeId, string userId, Recipe recipeData)
    {
        Recipe recipeToUpdate = GetAllRecipesById(recipeId);

        if(recipeToUpdate.CreatorId != userId)
        {
            throw new Exception("YOU CANNOT UPDATE A RECIPE YOU DID NOT CREATE, THAT IS FORBIDDEN, PLEASE IGNORE THE 400 ERROR CODE, IT SHOULD BE 403");
        }

        recipeToUpdate.Instructions = recipeData.Instructions ?? recipeToUpdate.Instructions;
        recipeToUpdate.Img = recipeData.Img ?? recipeToUpdate.Img;
        recipeToUpdate.Title = recipeData.Title ?? recipeToUpdate.Title;
        recipeToUpdate.Category = recipeData.Category ?? recipeToUpdate.Category;

    _repository.UpdateRecipe(recipeToUpdate);

    return recipeToUpdate;

    }
}
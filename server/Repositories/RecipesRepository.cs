

namespace all_spice.Repositories;

public class RecipesRepository
{
    private readonly IDbConnection _db;
    public RecipesRepository(IDbConnection db)
    {
        _db = db;
    }

    public Recipe CreateRecipe(Recipe recipeData)
    {
        string sql = @"
        INSERT INTO
        recipes(creatorId, title, instructions, category, img)
        VALUES(@creatorId, @title, @instructions, @category, @img);

        SELECT
         recipes.*,
         accounts.*
         FROM recipes
         JOIN accounts ON accounts.id = recipes.creatorId
         WHERE recipes.id = LAST_INSERT_ID();";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile) =>
        {
            recipe.Creator = profile;
            return recipe;
        }, recipeData).FirstOrDefault();
        return recipe;
    }

    public List<Recipe> GetAllRecipes()
    {
        string sql = @"
      SELECT
      recipes.*,
      accounts.*
      FROM recipes
      JOIN accounts ON accounts.id = recipes.creatorId;";

        List<Recipe> recipes = _db.Query<Recipe, Profile, Recipe>(sql, (recipe, profile)
         =>
        {
            recipe.Creator = profile;
            return recipe;
        }).ToList();

        return recipes;
    }
}
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

    public void DeleteRecipe(int recipeId)
    {
        string sql = "DELETE FROM recipes WHERE id = @recipeId LIMIT 1;";

        int rowsAffected = _db.Execute(sql, new { recipeId });

        if (rowsAffected == 0) throw new Exception("DELETE FAILED");
        if (rowsAffected > 1) throw new Exception("DELETE WAS OVER POWERED");
    }

    internal Recipe GetAllRecipesById(int recipeId)
    {
        string sql = @"
    SELECT
    recipes.*,
    accounts.*
    FROM recipes
    JOIN accounts ON accounts.id = recipes.creatorId
    WHERE recipes.id = @recipeId;";

        Recipe recipe = _db.Query<Recipe, Profile, Recipe>(sql, JoinCreator, new { recipeId }).FirstOrDefault();
        return recipe;
    }


    private Recipe JoinCreator(Recipe recipe, Profile profile)
    {
        recipe.Creator = profile;
        return recipe;
    }

    internal void UpdateRecipe(Recipe recipeToUpdate)
    {
        string sql = @"
UPDATE
recipes
SET
title = @title,
instructions = @instructions,
category =  @category,
img = @img
WHERE id = @Id LIMIT 1;";

        int rowsAffected = _db.Execute(sql, recipeToUpdate);

        if (rowsAffected == 0) throw new Exception("UPDATE FAILED");
        if (rowsAffected > 1) throw new Exception("UPDATE DID NOT FAIL, BUT THAT IS STILL A PROBLEM");
    }
}



namespace all_spice.Repositories;

public class IngredientsRepository
{
    private readonly IDbConnection _db;
    public IngredientsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Ingredients CreateIngredient(Ingredients ingredientData, Account userInfo)
    {
        string sql = @"
            INSERT INTO
            ingredients(name, quantity, recipeId)
            VALUES(@name, @quantity, @recipeId);
            SELECT
            ingredients.*,
            recipes.*
            FROM ingredients
            JOIN recipes ON recipes.id = ingredients.recipeId
            WHERE ingredients.id = LAST_INSERT_ID();";


        Ingredients ingredients = _db.Query<Ingredients, Profile, Ingredients>(sql, JoinCreator, ingredientData).FirstOrDefault();

        return ingredients;
    }

    internal List<Ingredients> GetIngredientsForRecipe(int recipeId)
    {
        string sql = @"
        SELECT
        ingredients.*,
        recipes.*
        FROM ingredients
        JOIN recipes ON recipes.id = ingredients.recipeId
        WHERE ingredients.recipeId  = @recipeId;";

        List<Ingredients> ingredients = _db.Query<Ingredients, Profile, Ingredients>(sql, JoinCreator, new { recipeId }).ToList();
        return ingredients;

    }



    private Ingredients JoinCreator(Ingredients ingredients, Profile profile)
    {
        ingredients.Creator = profile;
        return ingredients;
    }
}


namespace all_spice.Repositories;

public class FavoritesRepository
{
    private readonly IDbConnection _db;

    public FavoritesRepository(IDbConnection db)
    {

        _db = db;
    }

    internal FavoriteRecipe CreateFavoriteRecipe(Favorite favoriteData, Account userInfo)
    {
        string sql = @"
        INSERT INTO
        favorites (accountId, recipeId)
        VALUES(@AccountId, @RecipeId);
        
        SELECT
        favorites.*
        accounts.*,
        FROM favorites
        JOIN accounts ON accounts.id = favorites.accountId
        WHERE favorites.id = @userId
        ;";

        FavoriteRecipe favoriteRecipe = _db.Query<Favorite, FavoriteRecipe, FavoriteRecipe>(sql, (favorite, favoriteRecipe) =>
        {
            favoriteRecipe.FavoriteId = favorite.Id;
            favoriteRecipe.RecipeId = favorite.RecipeId;
            favoriteRecipe.AccountId = favorite.AccountId;

            // cultist.CultMemberId = cultMember.Id;
            // cultist.CultId = cultMember.CultId;
            // cultist.AccountId = cultMember.AccountId;

            return favoriteRecipe;
        }, favoriteData).FirstOrDefault();
        return favoriteRecipe;
    }
}
//  'creatorId', 'title', 'img',  'category', 'creator'

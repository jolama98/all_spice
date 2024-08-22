


namespace all_spice.Services;

public class FavoritesService
{
    private readonly FavoritesRepository _favoritesRepository;

    public FavoritesService(FavoritesRepository favoritesRepository)
    {
        _favoritesRepository = favoritesRepository;
    }

    internal FavoriteRecipe CreateFavoriteRecipe(Favorite favoriteData, Account userInfo)
    {
        FavoriteRecipe favoriteRecipe = _favoritesRepository.CreateFavoriteRecipe(favoriteData, userInfo);
        return favoriteRecipe;
    }

}
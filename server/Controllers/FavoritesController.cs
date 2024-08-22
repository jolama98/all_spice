namespace all_spice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class favoritesController : ControllerBase
{
    private readonly FavoritesService _favoritesService;
    private readonly Auth0Provider _auth0Provider;

    public favoritesController(FavoritesService favoritesService, Auth0Provider auth0Provider)
    {
        _auth0Provider = auth0Provider;
        _favoritesService = favoritesService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<FavoriteRecipe>> CreateFavoriteRecipe([FromBody] Favorite favoriteData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.AccountId = userInfo.Id;
            FavoriteRecipe favoriteRecipe = _favoritesService.CreateFavoriteRecipe(favoriteData, userInfo);
            return Ok(favoriteRecipe);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}

// public async Task<ActionResult<Cultist>> CreateCultMember([FromBody] CultMember cultMemberData)
// {
//     try
//     {
//         Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
//         cultMemberData.AccountId = userInfo.Id;
//         Cultist cultist = _cultMembersService.CreateCultMember(cultMemberData);
//         return Ok(cultist);
//     }
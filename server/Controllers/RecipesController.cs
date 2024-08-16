namespace all_spice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly RecipeService _recipeService;
    private readonly Auth0Provider _auth0Provider;
    private readonly IngredientsService _ingredientsService;



    public RecipesController(RecipeService recipeService, Auth0Provider auth0Provider, IngredientsService ingredientsService)
    {
        _recipeService = recipeService;
        _auth0Provider = auth0Provider;
        _ingredientsService = ingredientsService;
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = _recipeService.CreateRecipe(recipeData);
            return Ok(recipe);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
        try
        {
            List<Recipe> recipes = _recipeService.GetAllRecipes();
            return Ok(recipes);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetAllRecipesById(int recipeId)
    {
        try
        {
            Recipe recipe = _recipeService.GetAllRecipesById(recipeId);
            return Ok(recipe);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpDelete("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<string>> DestroyRecipe(int recipeId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string message = _recipeService.DestroyRecipe(recipeId, userInfo.Id);

            return Ok(message);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPut("{recipeId}")]
    [Authorize]

    public async Task<ActionResult<Recipe>> UpdateRecipe(int recipeId, [FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Recipe recipe = _recipeService.UpdateRecipe(recipeId, userInfo.Id, recipeData);
            return Ok(recipe);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("{recipeId}/ingredients")]


    public ActionResult<List<Ingredients>> GetIngredientsForRecipe(int recipeId)
    {
        try
        {
            List<Ingredients> ingredients = _ingredientsService.GetIngredientsForRecipe(recipeId);
            return ingredients;
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }



}
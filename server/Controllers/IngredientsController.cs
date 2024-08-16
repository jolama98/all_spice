using System.Reflection.Metadata.Ecma335;

namespace all_spice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
    private readonly Auth0Provider _auth0Provider;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth0Provider)
    {
        _auth0Provider = auth0Provider;
        _ingredientsService = ingredientsService;

    }
    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Ingredients>> CreateIngredients([FromBody] Ingredients ingredientData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Ingredients ingredients = _ingredientsService.CreateIngredient(ingredientData, userInfo);
            return Ok(ingredients);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }


}
namespace all_spice.Controllers;

[ApiController]
[Route("api/[controller]")]

public class IngredientsController : ControllerBase
{
    private readonly IngredientsService _ingredientsService;
}

//           CultMember
public class Favorite : RepoItem<int>
{

    public int RecipeId { get; set; }
    public string AccountId { get; set; }

}

//           Cultist 
public class FavoriteRecipe : Profile
{
    public int FavoriteId { get; set; }
    public int RecipeId { get; set; }
    public string AccountId { get; set; }

}

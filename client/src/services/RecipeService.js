import { AppState } from "@/AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "@/models/Recipes.js"

class RecipeService {
  async getRecipes() {
    const response = await api.get('api/recipes')
    logger.log('GOT RECIPES 🍔', response.data)
    const recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
    AppState.recipes = recipes
  }
}
export const recipeService = new RecipeService()


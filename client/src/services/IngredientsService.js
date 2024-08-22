import { Ingredient } from "@/models/Ingredient.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"

class IngredientsService {
  async createIngredient(ingredientData) {
    ingredientData.recipeId = AppState.activeRecipes.id
    const response = await api.post('api/ingredients', ingredientData)
    logger.log(response.data)
    const newIngredient = new Ingredient(response.data)
    AppState.ingredients.push(newIngredient)


    // async createRecipe(recipeData) {
    // const response = await api.post('api/recipes', recipeData)
    // const newRecipe = new Recipe(response.data)
    // AppState.recipes.unshift(newRecipe)
    // return newRecipe
  }
  async getIngredientsByRecipeId(id) {
    let response = await api.get(`api/recipes/${id}/ingredients`)
    logger.log(response.data)
    let ingredients = response.data.map((data) => new Ingredient(data))
    AppState.ingredients = ingredients;
  }
}
export const ingredientsService = new IngredientsService()

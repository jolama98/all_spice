import { AppState } from "@/AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "../models/Recipes.js"

class RecipeService {

  setActiveRecipe(recipeProp) {
    AppState.activeRecipes = recipeProp
  }

  async getRecipeById(recipeId) {
    AppState.activeRecipes = null

    const response = await api.get(`api/recipes/${recipeId}`)
    logger.log('🖼️📡🧌', response.data)

    const recipe = new Recipe(response.data)
    AppState.activeRecipes = recipe

  }

  async getAllRecipes() {
    const response = await api.get('api/recipes')
    logger.log('GOT RECIPES 🍔', response.data)
    const recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
    AppState.recipes = recipes
  }
}

export const recipeService = new RecipeService()


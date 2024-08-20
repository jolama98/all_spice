import { AppState } from "@/AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "../models/Recipes.js"

class RecipeService {

  setActiveRecipe(recipes) {
    AppState.activeRecipes = recipes
  }

  async getRecipeById(recipes) {
    AppState.activeRecipes = null

    const response = await api.get(`api/recipes/${recipes}`)
    logger.log('🖼️📡🧌', response.data)

    const recipe = new Recipe(response.data)
    AppState.activeRecipes = recipe
  }

  async createRecipe(recipeData) {
    const response = await api.post('api/recipes', recipeData)
    const newRecipe = new Recipe(response.data)
    AppState.recipes.unshift(newRecipe)
    return newRecipe
  }

  // async createEvent(eventData) {
  //   const response = await api.post('api/events', eventData)
  //   const newEvent = new Event(response.data)
  //   AppState.events.unshift(newEvent)
  //   return newEvent
  // }

  async getAllRecipes() {
    const response = await api.get('api/recipes')
    logger.log('GOT RECIPES 🍔', response.data)
    const recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
    AppState.recipes = recipes
  }
}

export const recipeService = new RecipeService()


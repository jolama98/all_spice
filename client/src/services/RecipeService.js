import { AppState } from "@/AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { Recipe } from "../models/Recipes.js"

class RecipeService {

  async destroyRecipe(recipeId) {
    const response = await api.delete(`api/recipes/${recipeId}`)
    logger.log(response.data)
    const recipeIndex = AppState.recipes.findIndex(recipe => recipe.id == recipeId)
    if (recipeIndex == -1) throw new Error("You messed up on findIndex, big fella")
    AppState.recipes.splice(recipeIndex, 1)
  }


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


  async editRecipeInstruction(instructions) {
    const response = await api.put(`api/recipes/${AppState.activeRecipes.id}`, { instructions: instructions.value })
    const newRecipe = new Recipe(response.data)
    AppState.activeRecipes = newRecipe
    const index = AppState.recipes.findIndex((recipe) => recipe.id == AppState.activeRecipes.id)
    AppState.recipes[index] = newRecipe
    return (AppState.activeRecipes)
  }


  async getAllRecipes() {
    const response = await api.get('api/recipes')
    logger.log('GOT RECIPES 🍔', response.data)
    const recipes = response.data.map(recipePOJO => new Recipe(recipePOJO))
    AppState.recipes = recipes
  }
}

export const recipeService = new RecipeService()


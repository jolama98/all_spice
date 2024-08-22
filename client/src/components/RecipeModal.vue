<script setup>
import { AppState } from '@/AppState.js';
import { Recipe } from '../models/Recipes.js';
import { computed, ref } from 'vue';
import Pop from '@/utils/Pop.js';
import { recipeService } from '@/services/RecipeService.js';
import { Modal } from 'bootstrap';
import { ingredientsService } from '@/services/IngredientsService.js';
import { logger } from '@/utils/Logger.js';

defineProps({ recipes: Recipe })

const ingredients = computed(() => AppState.ingredients)

const instructions = ref('')
const activeRecipe = computed(() => {
  return (AppState.activeRecipes)
})


const recipe = computed(() => AppState.activeRecipes)
const account = computed(() => AppState.account)

async function destroyRecipe(recipeId) {
  try {
    const recipeToDestroy = await Pop.confirm("???")
    if (recipeToDestroy == false) {
      return
    }
    await recipeService.destroyRecipe(recipeId)
    Modal.getOrCreateInstance('#recipeModal').hide()
    Pop.success('Recipe was deleted  successfully')
  }
  catch (error) {
    Pop.error(error);
  }
}

async function makeIngredient() {
  try {
    ingredientsService.createIngredient(ingredientData.value)
  }
  catch (error) {
    Pop.error(error);
  }
}
const ingredientData = ref({
  quantity: 0,
  name: ''
})

async function editRecipe() {
  try {
    const newRecipe = await recipeService.editRecipeInstruction(instructions)
    logger.log(newRecipe)
    Pop.success("edited")
  }
  catch (error) {
    Pop.error(error);
  }
}
let edit = ref(false)

</script>


<template>
  <div class="modal fade container-fluid" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-xl ">
      <div class="modal-content">
        <div class="row">
          <div class="col-5">
            <div class="p-1">
              <img class="img-fluid" :src="recipe?.img" alt="">
            </div>
          </div>

          <div class="col-7">

            <div class="card border-0">
              <div class="d-flex p-2 justify-content-between ">
                <h2>{{ recipe?.title }} <button class="btn  fs-1" data-bs-toggle="dropdown" aria-expanded="false"
                    v-if="account?.id == recipe?.creator.id">...</button>
                  <div class="dropdown">
                    <ul class="dropdown-menu">
                      <li><button class="dropdown-item btn del-btn " @click="destroyRecipe(recipe.id)">Delete</button>
                      </li>
                      <li><button class="dropdown-item btn edit-btn" @click="edit = !edit">Edit
                          Recipe</button>
                      </li>
                    </ul>
                  </div>
                </h2>
                <button type="button" class="btn-close p-2" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div v-if="edit" class="p-1">
                <div class="d-flex flex-column justify-content-between">
                  <p class="text-bg rounded-5 p-2 d-flex align-self-start text-light">{{ recipe?.category }}</p>
                  <p>By {{ recipe?.creator.name }}</p>
                </div>
                <form @submit.prevent="editRecipe()" class="">
                  <p class="fw-bold">Instructions</p>
                  <p>{{ recipe?.instructions }}</p>
                  <div class="mt-3 d-flex">
                    <textarea v-model="instructions" class="form-control" id="instructionsTextArea" rows="6"
                      style="resize: none;"></textarea>
                    <button type="submit" class="btn btn-success w-25 align-self-end mb-2">Save</button>
                  </div>
                </form>
                <h4 class="mt-3">Ingredients:</h4>
                <div class="">
                  <form @submit.prevent="makeIngredient()" class="input-group">
                    <input v-model="ingredientData.quantity" type="text" aria-label="quantity" class="form-control"
                      placeholder="quantity">
                    <input v-model="ingredientData.name" type="text" aria-label="ingredient" class="form-control w-50"
                      placeholder="new ingredient text">
                    <button class="btn " type="submit">Add</button>
                  </form>
                </div>
              </div>
              <div v-else class="p-1">
                <div class="d-flex flex-column justify-content-between">
                  <p class="text-bg rounded-5 p-2 d-flex align-self-start text-light">{{ recipe?.category }}</p>
                  <p>By {{ recipe?.creator.name }}</p>
                </div>
                <p class="fw-bold">Instructions</p>
                <p>{{ recipe?.instructions }}</p>
                <h4 class="mt-3">Ingredients:</h4>

                <div v-for="ingredient in ingredients" :key="ingredient.id" class="d-flex">
                  <p class="mb-1"><span type="button" @click="console.log('click')"
                      class="text-danger fw-bolder">X</span>
                    {{ ingredient.quantity }} {{ ingredient.name }}</p>
                  <div v-for="ingredient in ingredients" :key="ingredient.id" class="d-flex">
                    <p class="mb-1">• {{ ingredient.quantity }} {{ ingredient.name }}</p>
                  </div>


                </div>
              </div>

            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>


<style lang="scss" scoped>
.text-bg {
  background: rgba(0, 0, 0, 0.507);
}

img {
  height: 100%;
}

.edit-btn:hover {
  background-color: rgb(0, 183, 255);
  color: beige;
}

.del-btn:hover {
  background-color: red;
  color: beige;
}
</style>

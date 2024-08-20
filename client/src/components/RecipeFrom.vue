<script setup>
import { ref } from 'vue';
import Pop from '../utils/Pop.js';
import { recipeService } from '../services/RecipeService.js'
import { logger } from '../utils/Logger.js';

import { Modal } from 'bootstrap';
import { useRouter } from 'vue-router';

const recipeData = ref({
  title: '',
  category: '',
  img: '',
  instructions: ''

})
async function createRecipe() {
  try {
    await recipeService.createRecipe(recipeData.value)
    Modal.getOrCreateInstance('#recipeFormModal').hide()
    recipeData.value = {
      title: '',
      category: '',
      img: '',
      instructions: ''
    }
  }
  catch (error) {
    Pop.error(error)
    logger.error(error)
  }
}


</script>


<template>
  <form @submit.prevent="createRecipe()">
    <div class="modal fade" id="recipeFormModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header bg-success ">
            <h1 class="modal-title fs-1 sahitya-font" id="exampleModalLabel">New Recipe</h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <div class="mb-3">
              <label for="recipeInputTitle" class="form-label">Title</label>
              <input v-model="recipeData.title" type="text" class="form-control" id="recipeInputTitle"
                aria-describedby="recipeInputTitle" minlength="3" maxlength="1000" required
                placeholder="Beast Birthday Cake">
            </div>
            <div class="mb-3">
              <label for="recipeInputCategory" class="form-label">Category</label>
              <select v-model="recipeData.category" required class="form-control" id="recipeInputCategory">
                <option value="" disabled>Please Select A Category</option>
                <option value="all">All</option>
                <option value="breakfast">Breakfast</option>
                <option value="lunch">Lunch</option>
                <option value="dinner">Dinner</option>
                <option value="snack">Snack</option>
                <option value="dessert">Dessert</option>
              </select>
            </div>
            <div class="mb-3">
              <label for="recipeInputImg" class="form-label">Recipe Image</label>
              <input v-model="recipeData.img" type="url" class="form-control" id="recipeInputImg"
                aria-describedby="recipeInputImg" maxlength="4000" required placeholder="ImgUrl">
            </div>
            <div class="mb-3">
              <label for="recipeInputInstructions" class="form-label">Recipe Instructions</label>
              <input v-model="recipeData.instructions" type="text" class="form-control" id="recipeInputInstructions"
                aria-describedby="recipeInputInstructions" maxlength="3000" required
                placeholder="Have Your Brother Make It">
            </div>

          </div>
          <div class="mb-2 m-2 form-check d-flex justify-content-end ">

            <button class="btn btn-primary" type="submit">Submit</button>
          </div>
        </div>
      </div>
    </div>

  </form>
</template>


<style lang="scss" scoped></style>

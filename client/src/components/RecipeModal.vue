<script setup>
import { router } from '@/router.js';
import { Recipe } from '../models/Recipes.js';
import { recipeService } from '@/services/RecipeService.js';
import { logger } from '@/utils/Logger.js';


const props = defineProps({
  recipeProp: { type: Recipe, required: true },
  // instructionsProp: { type: Instructions, required: true }
})


async function setActiveRecipe() {
  recipeService.setActiveRecipe(props.recipeProp)
  await router.push({ query: { recipeId: `${props.recipeProp.id}` } })
  logger.log(router.currentRoute)
}
</script>


<template>
  <div class="modal fade container-fluid" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel"
    aria-hidden="true">
    <div class="modal-dialog modal-xl ">
      <div class="modal-content">
        <div class="row">
          <div class="col-5">
            <div class="p-1">
              <img class="img-fluid" :src="props.recipeProp.img" alt="">
            </div>
          </div>

          <div class="col-7">
            <div class="card border-0 ">
              <div class="d-flex justify-content-between p-3">
                <p class="text-bg rounded-5 p-2 d-flex align-self-start text-light">{{ recipeProp.category }}</p>
                <button @click="setActiveRecipe()" type="button" class="btn-close p-2" data-bs-dismiss="modal"
                  aria-label="Close"></button>
              </div>
              <h1>{{ recipeProp.title }}</h1>
              <p>{{ recipeProp.instructions }}</p>
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
</style>

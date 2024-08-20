<script setup>
import { AppState } from '@/AppState.js';
import { Recipe } from '../models/Recipes.js';
import { computed } from 'vue';



defineProps({ recipes: Recipe })
// instructionsProp: { type: Instructions, required: true }


const recipe = computed(() => AppState.activeRecipes)

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
            <div class="card border-0 ">
              <div class="d-flex  justify-content-between p-3">
                <p class="text-bg rounded-5 p-2 d-flex align-self-start text-light">{{ recipe?.category }}</p>
                <p>By {{ recipe?.creator.name }}</p>
                <button type="button" class="btn-close p-2" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <h1>{{ recipe?.title }}</h1>
              <p>Instructions</p>
              <p>{{ recipe?.instructions }}</p>
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

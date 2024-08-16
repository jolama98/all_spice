<script setup>
import { Recipe } from '../models/Recipes.js';

const props = defineProps({
  recipeProp: { type: Recipe, required: true }
})
</script>


<template>

  <div class="card mt-5">
    <div class="card-body d-flex flex-column justify-content-between">
      <div class="text-bg rounded-5 p-1 d-flex align-self-start">
        <p class="card-text text-light m-1">{{ props.recipeProp.category }}</p>
      </div>
      <div class="text-bg rounded-2 p-1 ">
        <p class="card-text text-light m-1">{{ props.recipeProp.title }}</p>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.text-bg {
  background: rgba(0, 0, 0, 0.507);
}

.card {
  height: 25vh;
  background-image: v-bind('recipeProp.recipeBackgroundImage');
  background-position: center;
  background-size: cover;
}
</style>

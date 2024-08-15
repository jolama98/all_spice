<script setup>
import { Recipe } from '../models/Recipes.js';


defineProps({ recipe: Recipe})
</script>


<template>

  <div class="card mt-5">
    <div class="card-body">
      <div class=" text-bg rounded-2 ">
        <p class="card-text text-light m-1 align-self-end">{{ recipe.title }}
        </p>
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
  background-image: v-bind("recipe.img");
  background-position: center;
  background-size: cover;
}
</style>

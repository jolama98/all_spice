<script setup>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { recipeService} from '../services/RecipeService.js'
import { AppState } from '../AppState.js';
import RecipeCard from '../components/RecipeCard.vue';

const recipes = computed(() => AppState.recipes)
onMounted(() => { getRecipes() })

async function getRecipes() {
  try {
    await recipeService.getRecipes()
  } catch (error) {
Pop.error(error)
  }

}
</script>

<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="img-fluid header-img d-flex justify-content-center"></div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-4" v-for="recipe in recipes" :key="recipe.id">
        <RecipeCard :recipe="recipe" />
      </div>
    </div>
  </div>
</template>

<style scoped lang="scss">
.header-img {
  height: 25vh;
  background-image: url("https://images.unsplash.com/photo-1525203135335-74d272fc8d9c?q=80&w=1600&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D");
  background-position: center;
  background-size: cover;
}
</style>

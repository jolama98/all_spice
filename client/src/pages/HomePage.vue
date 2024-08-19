<script setup>
import { computed, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { recipeService } from '../services/RecipeService.js'
import { AppState } from '../AppState.js';
import RecipeCard from '../components/RecipeCard.vue';
import RecipeModal from '../components/RecipeModal.vue';

const recipes = computed(() => AppState.recipes)

onMounted(() => {
  getAllRecipes()
})


async function getAllRecipes() {
  try {
    await recipeService.getAllRecipes()
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
        <div class="filter-btn d-flex justify-content-center ">
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-4" v-for="recipe in recipes" :key="recipe.id">
        <RecipeCard :recipeProp="recipe" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#recipeModal" />
      </div>
    </div>
    <div v-for="recipe in recipes" :key="recipe.id">
      <RecipeModal :recipeProp="recipe" />
    </div>
  </div>
</template>

<style scoped lang="scss">
.header-img {
  height: 30vh;
  background-image: url("../assets/scss/img/forJoe.jpg");
  background-position: center;
  background-size: cover;
}

.filter-btn {
  margin-top: -2%;
  height: 3vh;
}
</style>

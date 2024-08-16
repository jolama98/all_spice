<script setup>
import { computed, onMounted, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { recipeService} from '../services/RecipeService.js'
import { AppState } from '../AppState.js';
import RecipeCard from '../components/RecipeCard.vue';
import RecipeModal from '@/components/RecipeModal.vue';

const categoryFilter = ref('home')

onMounted(() => { getAllRecipes() })

const categories = ["home","my recipe", "fav", ]

const recipes = computed(() => {
  if (categoryFilter.value == 'home') {
    return AppState.recipes
  }
  return AppState.recipes.filter(recipe => recipe.category == categoryFilter.value)
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
  <RecipeModal />
  <div class="container-fluid">
    <div class="row">
      <div class="col-12">
        <div class="img-fluid header-img d-flex justify-content-center"></div>
        <div class="filter-btn d-flex justify-content-center ">
          <div class="col-md-2 m-1" v-for="category in categories" :key="category">
            <a @click="categoryFilter = category" class="text-capitalize btn btn-light rounded text-center fw-bold">
              {{ category }}
            </a>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col-md-4" v-for="recipe in recipes" :key="recipe.id">
        <RecipeCard :recipeProp="recipe" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#recipeModal" />
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
.filter-btn{
margin-top: -2%;
height: 3vh;
}
</style>

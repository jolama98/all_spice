<script setup>
import { AppState } from '@/AppState.js';
import { Recipe } from '../models/Recipes.js';
import { computed } from 'vue';
import Pop from '@/utils/Pop.js';
import { recipeService } from '@/services/RecipeService.js';
import { Modal } from 'bootstrap';

defineProps({ recipes: Recipe })
// instructionsProp: { type: Instructions, required: true }

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

function editRecipe() {

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
              <img class="img-fluid" :src="recipe?.img" alt="">
            </div>
          </div>

          <div class="col-7">
            <div class="card border-0">
              <div class="d-flex p-2 justify-content-between ">
                <h2>{{ recipe?.title }} <button class="btn  fs-1" data-bs-toggle="dropdown" aria-expanded="false"
                    v-if="account?.id == recipe.creator?.id">...</button>
                  <div class="dropdown">
                    <ul class="dropdown-menu">
                      <li><button class="dropdown-item btn del-btn " @click="destroyRecipe(recipe.id)">Delete</button>
                      </li>
                      <li><button class="dropdown-item btn edit-btn" @click="editRecipe()">Edit Recipe</button>
                      </li>
                    </ul>
                  </div>
                </h2>
                <button type="button" class="btn-close p-2" data-bs-dismiss="modal" aria-label="Close"></button>
              </div>
              <div class="d-flex flex-column justify-content-between">
                <p class="text-bg rounded-5 p-2 d-flex align-self-start text-light">{{ recipe?.category }}</p>
                <p>By {{ recipe?.creator.name }}</p>
              </div>
              <p class="fw-bold">Instructions</p>
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

.edit-btn:hover {
  background-color: rgb(0, 183, 255);
  color: beige;
}

.del-btn:hover {
  background-color: red;
  color: beige;
}
</style>

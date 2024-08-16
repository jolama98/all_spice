<script setup>
import { computed, onMounted } from 'vue';
import { Recipe } from '../models/Recipes.js';
import { AppState } from '@/AppState.js';
import Pop from '@/utils/Pop.js';
import { logger } from '@/utils/Logger.js';
import { useRoute } from 'vue-router';
import { recipeService } from '@/services/RecipeService.js';

// defineProps({ event: Event })



// function setActiveEvent(event) {
//   eventsService.setActiveEvent(event)
//   logger.log(eventsService.setActiveEvent)
// }


defineProps({ recipe: Recipe })

function setActiveRecipe(recipe){
  recipeService.setActiveRecipe(recipe)
}


// onMounted(() => {
//   getRecipeById()
// })


// async function getRecipeById() {
//   try {

//     await recipeService.getRecipeById(recipesId)

//   } catch (error) {
//     Pop.toast("Could not get Recipe", 'error', 'top-start')
//     logger.error(error)
//   }
// }

</script>
  <template>
    <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h1 class="modal-title fs-5" id="recipeModalLabel">{{ recipe?.title }}</h1>
            <button @click="setActiveRecipe()" type="button" class="btn-close" data-bs-dismiss="modal"
              aria-label="Close"></button>
          </div>
          <div class="modal-body">
            {{ recipe?.instructions }}
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
          </div>
        </div>
      </div>
    </div>
  </template>


<style lang="scss" scoped>

</style>

<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
  </div>
</template>

<script>
import { computed, onMounted } from "vue"
import { AppState } from "../AppState"
import productsService from "../services/ProductsService"
export default {
  name: 'Home',
  setup(){
  onMounted(() => {
    productsService.getAvailableProducts()
  })
  return{
    products: computed(() => AppState.availableProducts)
  }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
  background-color: #6DD3FF;
}
</style>

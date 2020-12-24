<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="row">
      <products-component v-for="p in products" :product-prop="p" :key="p.id" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { productsService } from '../services/ProductsService'
import ProductsComponent from '../components/ProductsComponent.vue'
export default {
  components: { ProductsComponent },
  name: 'Home',
  setup() {
    onMounted(async() => {
      await productsService.getAvailableProducts()
    })
    return {
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

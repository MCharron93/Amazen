<template>
  <div class="row">
    <product-component />
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { productComponent } from '../components/SingleProductComponent'
import { useRoute } from 'vue-router'
import { productsService } from '../services/ProductsService'

export default {
  name: 'SingleProductPage',
  components: { productComponent },
  setup() {
    const route = useRoute()
    onMounted(async() => {
      await productsService.getSingleProduct(route.params.id)
    })
    return {
      singleProduct: computed(() => AppState.singleProduct)
    }
  }
}
</script>

<style>

</style>

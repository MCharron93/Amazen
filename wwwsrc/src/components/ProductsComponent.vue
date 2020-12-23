<template>
  <div class="products-component col-4 card" @click="getSingleProduct(productProp.id)">
    {{ productProp.name }}
  </div>
</template>

<script>
import { computed } from 'vue'
import { productsService } from '../services/ProductsService'
import { useRouter } from 'vue-router'

export default {
  name: 'ProductsComponent',
  props: {
    productProp: Object
  },
  setup(props) {
    const router = useRouter()
    return {
      product: computed(() => props.productProp),
      getSingleProduct(productId) {
        productsService.getSingleProduct(productId)
        router.push({ name: 'SingleProductPage' })
      }
    }
  }
}
</script>

<style>

</style>

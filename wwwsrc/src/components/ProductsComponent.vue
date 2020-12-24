<template>
  <div class="products-component col-4 card" @click="getSingleProduct(productProp.id)">
    <h3>
      {{ productProp.name }}
    </h3>
    <div>
      <img class="img-fluid" :src="(productProp.picture)" alt="Responsive Image">
    </div>
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
      getSingleProduct() {
        router.push({ name: 'SingleProduct', params: { id: props.productProp.id } })
        productsService.getSingleProduct(props.productProp.id)
      }
    }
  }
}
</script>

<style>

</style>

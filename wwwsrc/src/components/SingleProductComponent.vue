<template>
  <div class="productComponent col-8 card">
    <h2>
      {{ product.name }}
    </h2>
    <img class="img-fluid" :src="(product.picture)" alt="Responsive Image">
    <p>{{ product.description }}</p>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'

export default {
  name: 'ProductComponent',
  setup() {
    return {
      product: computed(() => AppState.singleProduct)
    }
  }
}
</script>

<style>

</style>

<template>
  <div class="row">
    <product-component />
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { productComponent } from '../components/SingleProductComponent'
export default {
  name: 'SingleProductPage',
  components: { productComponent },
  setup() {
    return {
      singleProduct: computed(() => AppState.singleProduct)
    }
  }
}
</script>

<style>

</style>

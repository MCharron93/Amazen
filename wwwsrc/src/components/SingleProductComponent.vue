<template>
  <div class="productComponent col-8 card">
    <h2>
      {{ productProp.name }}
    </h2>
    <img class="img-fluid" :src="(productProp.picture)" alt="Responsive Image">
    <p>{{ productProp.description }}</p>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'ProductComponent',
  props: {
    productProp: Object
  },
  setup(props) {
    return {
      product: computed(() => props.productProp)
    }
  }
}
</script>

<style>

</style>

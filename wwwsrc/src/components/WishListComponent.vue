<template>
  <div class="wish-list-Component col-4 card">
    {{ listProp.name }}
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'WishListComponent',
  props: {
    listProp: Object
  },
  setup(props) {
    return {
      list: computed(() => props.listProp)
    }
  }
}
</script>

<style>

</style>

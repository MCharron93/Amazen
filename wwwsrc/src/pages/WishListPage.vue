<template>
  <div class="container fluid">
    <h4>
      {{ listDetails.name }}
    </h4>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'WishListPage',
  setup() {
    return {
      listDetails: computed(() => AppState.singleWishList)
    }
  }
}
</script>

<style>

</style>

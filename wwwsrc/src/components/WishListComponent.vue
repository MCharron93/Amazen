<template>
  <div class="wish-list-Component col-4 card" @click="viewWish(listProp.id)">
    <h5>
      {{ listProp.name }}
    </h5>
  </div>
</template>

<script>
import { computed } from 'vue'
import { wishListService } from '../services/WishListService'
import { useRouter } from 'vue-router'
export default {
  name: 'WishListComponent',
  props: {
    listProp: Object
  },
  setup(props) {
    const router = useRouter()
    return {
      list: computed(() => props.listProp),
      viewWish() {
        router.push({ name: 'WishList', params: { id: props.listProp.id } })
        wishListService.getWishListById(props.listProp.id)
      }
    }
  }
}
</script>

<style>

</style>

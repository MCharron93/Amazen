<template>
  <div class="about text-center">
    <h1>Welcome {{ profile.name }}</h1>
    <img class="rounded" :src="profile.picture" alt="" />
    <p>{{ profile.email }}</p>
    <div class="row">
      <wish-list-component v-for="wl in myLists" :key="wl.id" :list-prop="wl" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { wishListService } from '../services/WishListService'
import WishListComponent from '../components/WishListComponent.vue'
export default {
  components: { WishListComponent },
  name: 'Profile',
  setup() {
    onMounted(() => {
      wishListService.getMyWishLists()
    })
    return {
      profile: computed(() => AppState.profile),
      myLists: computed(() => AppState.wishLists)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>

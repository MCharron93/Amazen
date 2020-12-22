<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
  <!---NOTE Here is where the products v-if will be loaded in, this page will have an onMounted to get all products to be displayed here--->
  </div>
</template>

<script>
export default {
  name: 'Home'

}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
  background-color: #6DD3FF;
}
</style>

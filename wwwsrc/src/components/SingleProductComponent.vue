<template>
  <div class="productComponent col-8 card py-3">
    <div class="row justify-content-between px-3">
      <h2>
        {{ product.name }}
      </h2>
      <div v-if="profile.id === product.creatorId">
        <button class="btn btn-info btn-sm" data-toggle="modal" data-target="#productEditForm">
          Edit?
        </button>&nbsp;&nbsp;&nbsp;
        <button class="btn btn-secondary btn-sm" @click="deleteItem()">
          &times;
        </button>
      </div>
    </div>
    <img class="img-fluid" :src="(product.picture)" alt="Responsive Image">
    <p>{{ product.description }}</p>
    <div class="row px-3 justify-content-between">
      <button class="col-2 btn btn-success">
        Add to Wishlist?
      </button>
      <button class="col-2 btn btn-secondary" v-if="profile.id === product.creatorId" @click="toggleAvailability()">
        Avaialbility
      </button>
    </div>

    <!-- Modal form for Editing item -->
    <div class="modal fade"
         id="productEditForm"
         tabindex="-1"
         role="dialog"
         aria-labelledby="productEditFormTitle"
         aria-hidden="true"
    >
      <form @submit.prevent="edit()">
        <div class="modal-dialog modal-dialog-centered" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5>
                Name:
                <input type="text" class="modal-title" id="exampleModalLongTitle" :placeholder="product.name" v-model="state.editData.name">
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              Description:
              <textarea cols="60" rows="10" :placeholder="product.description" v-model="state.editData.description"></textarea>
              Image URL:
              <input type="text" :placeholder="product.picture" v-model="state.editData.picture">
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-dismiss="modal">
                Close
              </button>
              <button class="btn btn-primary" type="submit">
                Save changes
              </button>
            </div>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { productsService } from '../services/ProductsService'
import { logger } from '../utils/Logger'

export default {
  name: 'ProductComponent',
  // props: {
  //   itemProp: Object
  // },
  setup() {
    const route = useRoute()
    const state = reactive({
      editData: {
        id: route.params.id
      }
    })
    return {
      state,
      profile: computed(() => AppState.profile),
      product: computed(() => AppState.singleProduct),
      edit() {
        productsService.editProduct(state.editData.id, state.editData)
      },
      deleteItem() {
        logger.log(route.params.id)
        productsService.delete(route.params.id)
      },
      toggleAvailability() {
        logger.log(route.params.id)
        productsService.toggleAvailability(route.params.id)
      }
    }
  }
}
</script>

<style>

</style>

<template>
  <nav class="navbar navbar-expand-lg navbar-dark row flex-column align-items-between">
    <div class="col-12 d-flex justify-content-between px-3">
      <router-link class="navbar-brand" :to="{ name: 'Home' }">
        <h3>
          Amazen
        </h3>
      </router-link>
      <div class="navbar-text">
        <button
          class="btn btn-outline-light text-uppercase"
          @click="login"
          v-if="!user.isAuthenticated"
        >
          Login
        </button>

        <div class="dropdown" v-else>
          <div
            class="dropdown-toggle"
            @click="state.dropOpen = !state.dropOpen"
          >
            <img
              :src="user.picture"
              alt="user photo"
              height="40"
              class="rounded"
            />
            <span class="mx-3">{{ user.name }}</span>
          </div>
          <div
            class="dropdown-menu p-0 list-group w-100"
            :class="{ show: state.dropOpen }"
            @click="state.dropOpen = false"
          >
            <router-link :to="{ name: 'Profile' }">
              <div class="list-group-item list-group-item-action hoverable">
                Profile
              </div>
            </router-link>
            <div
              class="list-group-item list-group-item-action hoverable"
              @click="logout"
            >
              logout
            </div>
          </div>
        </div>
      </div>
    </div>

    <div class="col-12 px-3 py-2 mx-3">
      <div>
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarText"
          aria-controls="navbarText"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon" />
        </button>
        <div class="collapse navbar-collapse" id="navbarText">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item border rounded border-white">
              <router-link :to="{ name: 'Home' }" class="nav-link">
                Store
              </router-link>
            </li>
            <li class="nav-item border rounded border-white">
              <router-link :to="{ name: 'About' }" class="nav-link">
                About
              </router-link>
            </li>
            <li class="nav-item border rounded border-white">
              <router-link :to="{ name: 'Profile' }" class="nav-link">
                Profile
              </router-link>
            </li>
            <li class="nav-item border rounded border-white" v-if="profile.id">
              <button class="btn nav-link" data-toggle="modal" data-target="#newProductForm">
                &#43; Product
              </button>
            </li>
          </ul>
        </div>
      </div>
    </div>

    <div class="modal fade"
         id="newProductForm"
         tabindex="-1"
         role="dialog"
         aria-labelledby="newProductFormTitle"
         aria-hidden="true"
    >
      <form @submit.prevent="create()">
        <div class="modal-dialog modal-dialog-centered" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5>
                Name:
                <input type="text" class="modal-title" id="exampleModalLongTitle" v-model="state.newProduct.name">
              </h5>
              <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              Description:
              <textarea cols="60" rows="10" v-model="state.newProduct.description"></textarea>
              <p class="my-2">
                Image URL:&nbsp;
                <input type="text" v-model="state.newProduct.picture">
              </p>
              <!-- <p class="my-2">
                In Stock?&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <input type="checkbox" checked>
              </p> -->
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
        </div>
      </form>
    </div>
  </nav>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
import { productsService } from '../services/ProductsService'
import { logger } from '../utils/Logger'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false,
      newProduct: {
        isAvailable: true
      }
    })
    return {
      state,
      profile: computed(() => AppState.profile),
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      },
      create() {
        logger.log(state.newProduct)
        productsService.createProduct(state.newProduct)
        this.state.newProduct.content = ''
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.nav-item .nav-link.router-link-exact-active{
  color: var(--white);
}
.navbar{
  background-color: #E09D5F;
}
</style>

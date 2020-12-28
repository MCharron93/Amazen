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

    <div class="col-12 px-3 mx-3">
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
            <li class="nav-item border rounded border-white">
              <div class="nav-link">
                &#43; Item
              </div>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
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

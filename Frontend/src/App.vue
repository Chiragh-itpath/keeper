<script setup lang="ts">
import NavBar from '@/components/NavBar.vue'
import SideBar from '@/components/SideBar.vue'
import { watch, reactive } from 'vue'
import { useRouter } from 'vue-router'
import { RouterEnum } from '@/enum/RouterEnum'

const state = reactive({
  isHome: false,
  isLogin: false,
  isSignup: false,
  isForgotPwd: false,
  is404: false
})
const router = useRouter()
watch(
  () => router.currentRoute.value.name,
  (name) => {
    state.isHome = name == RouterEnum.HOME
    state.isLogin = name == RouterEnum.LOGIN
    state.isSignup = name == RouterEnum.SIGNUP
    state.isForgotPwd = name == RouterEnum.FORGOT_PASSWORD
    state.is404 = name == RouterEnum.PAGE_NOT_FOUND
  }
)
const ToggleSideBarAndNavBar = (): boolean => {
  return state.isHome || state.isLogin || state.isSignup || state.isForgotPwd || state.is404
}
</script>

<template>
  <v-layout class="hide-scrollerbar">
    <side-bar v-if="!ToggleSideBarAndNavBar()"></side-bar>
    <nav-bar v-if="!ToggleSideBarAndNavBar()"></nav-bar>
    <v-main>
      <router-view> </router-view>
    </v-main>
  </v-layout>
</template>
<style>
router-link {
  text-decoration: none;
}
</style>

<script setup lang="ts">
import Button from './components/ButtonComponent.vue'
import SideBar from '@/components/SideBar.vue'
import { watch, reactive } from 'vue'
import { useRouter } from 'vue-router'
import { RouterEnum } from '@/enum/RouterEnum'
import { tagStore } from "@/stores/TagStore";
import { storeToRefs } from 'pinia'
import { onMounted } from 'vue'
const {GetAll} = tagStore()
const state = reactive({
  isHome: false,
  isLogin: false,
  isSignup: false,
  isForgotPwd: false,
  is404: false
})
const { Tags } = storeToRefs(tagStore())
const router = useRouter()
onMounted(async () => {
    await GetAll()
})
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
    <nav-bar v-if="!ToggleSideBarAndNavBar()"></nav-bar>
    <side-bar v-if="!ToggleSideBarAndNavBar()">
        <template #data>
          <Button variant="outlined" v-for="(tag, index) in Tags" :key="index">
              {{ tag.title }}
           </Button>
        </template>
    </side-bar>
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

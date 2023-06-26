<script setup lang="ts">
import Button from './components/ButtonComponent.vue'
import SideBar from '@/components/SideBar.vue'
import { watch, reactive } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { RouterEnum } from '@/enum/RouterEnum'
import { tagStore } from "@/stores/TagStore";
import { storeToRefs } from 'pinia'
import { onMounted } from 'vue'
import NavBar from './components/NavBar.vue'
import { TagTypeEnum } from './enum/TagTypeEnum'

const route=useRoute()
const {GetAll,GetByTagType} = tagStore()
const state = reactive({
  isHome: false,
  isLogin: false,
  isSignup: false,
  isForgotPwd: false,
  is404: false
})

const { Tags,TagsByType } = storeToRefs(tagStore())
const router = useRouter()
watch(route,async () => {
  if(route.name?.toString()==RouterEnum.PROJECT)
    await GetByTagType(TagTypeEnum.PROJECT)
  else
    await GetByTagType(TagTypeEnum.KEEP)
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
    <NavBar v-if="!ToggleSideBarAndNavBar()"></NavBar>
    <side-bar v-if="!ToggleSideBarAndNavBar()">
        <template #data>
          <v-row class="mt-10">
            <v-col col="12" sm="12" md="12" lg="12" class="ma-2 text-center" v-for="(tag, index) in TagsByType" :key="index">
            <Button variant="tonal" >
                    {{ tag.title }}
            </Button>
            </v-col>
          </v-row>   
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

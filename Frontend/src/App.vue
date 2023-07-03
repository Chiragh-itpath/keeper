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

const route = useRoute()
const { GetAll, GetByTagType, GetByTagTitle } = tagStore()
const state = reactive({
  isHome: false,
  isLogin: false,
  isSignup: false,
  isForgotPwd: false,
  is404: false,
  isItempage:false
})

const { Tags, TagsByType } = storeToRefs(tagStore())
const router = useRouter()



watch(
  () => router.currentRoute.value.name,
  (name) => {
    state.isHome = name == RouterEnum.HOME
    state.isLogin = name == RouterEnum.LOGIN
    state.isSignup = name == RouterEnum.SIGNUP
    state.isForgotPwd = name == RouterEnum.FORGOT_PASSWORD
    state.is404 = name == RouterEnum.PAGE_NOT_FOUND
    state.isItempage = name == RouterEnum.ITEM
  }
)
const ToggleSideBarAndNavBar = (): boolean => {
  return state.isHome || state.isLogin || state.isSignup || state.isForgotPwd || state.is404 ||state.isItempage
}

async function FindTag(title: string) {
  var res = await GetByTagTitle(title)
  if (route.name?.toString() == RouterEnum.PROJECT || route.name?.toString() == RouterEnum.PROJECT_BY_TAG)
    router.push({ name: RouterEnum.PROJECT_BY_TAG, params: { id: res.id } })
  else if (route.name?.toString() == RouterEnum.KEEP || route.name?.toString() == RouterEnum.KEEP_BY_TAG)
    router.push({ name: RouterEnum.KEEP_BY_TAG, params: { id: res.id } })
}
</script>

<template>
  <v-layout class="hide-scrollerbar">
    <NavBar v-if="!ToggleSideBarAndNavBar()"></NavBar>
    <side-bar v-if="!ToggleSideBarAndNavBar()">
      <template #data>
        <v-list color="transparent" class="mt-6">
          <v-list-item v-for="(tag, index) in TagsByType" :key="index" @click="FindTag(tag.title)">
            <v-icon color="primary" class="mr-2">mdi-tag</v-icon>
            <span>{{ tag.title }}</span>
          </v-list-item>
        </v-list>
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

<script setup lang="ts">
import NavBar from '@/components/NavBar.vue';
import SideBar from '@/components/SideBar.vue';
import { ref, type Ref, watch } from 'vue';
import { useRouter } from 'vue-router';
const isHome: Ref<boolean> = ref(true);
const router = useRouter();
watch(() => router.currentRoute.value.fullPath, (newPath) => {
    isHome.value = newPath == '/'
})
</script>

<template>
    <v-layout class="hide-scrollerbar">
        <side-bar v-if="!isHome"></side-bar>
        <nav-bar></nav-bar>
        <v-main>
            <router-view>
            </router-view>
        </v-main>
    </v-layout>
</template>
<style>
router-link {
    text-decoration: none;
}
</style>
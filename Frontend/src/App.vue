<script setup lang="ts">
import Loader from '@/components/Custom/LoaderComponent.vue'
import Toster from '@/components/VToster.vue'
</script>

<template>
    <Toster />
    <loader />
    <v-layout class="hide-scrollbar">
        <router-view name="NavBar" />
        <router-view name="SideBar" />
        <v-main>
            <router-view>
            </router-view>
        </v-main>
    </v-layout>
</template>
<style>
a {
    text-decoration: none;
}
</style>
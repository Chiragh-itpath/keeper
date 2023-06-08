<script setup lang="ts">
import NavBar from '@/components/NavBar.vue';
import SideBar from '@/components/SideBar.vue';
</script>

<template>
    <v-layout class="hide-scrollerbar">
        <side-bar></side-bar>
        <nav-bar></nav-bar>
        <v-main>
            <router-view>
            </router-view>
        </v-main>
    </v-layout>
</template>
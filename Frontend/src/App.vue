<script setup lang="ts">
import home from "@/pages/HomePage.vue"
</script>

<template>
    <div></div>

    <v-layout>
        
        <v-app-bar>
            <template v-slot:prepend> 
                
            </template>
            <v-app-bar-title>Keeper</v-app-bar-title>
            <template v-slot:append>
                <v-btn class="mx-3">Login</v-btn>
                <v-btn class="mx-3">Signup</v-btn>
            </template>
        </v-app-bar>
        
    </v-layout>
    <!-- <router-view>
    </router-view> -->
</template>


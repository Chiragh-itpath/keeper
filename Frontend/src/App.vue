<script setup lang="ts">
import ButtonComponent from "./components/ButtonComponent.vue";

</script>

<template>
    <div></div>

    <v-layout>
        
        <v-app-bar>
            <template v-slot:prepend> 
            </template>
            <v-app-bar-title>Keeper</v-app-bar-title>
            <template v-slot:append>
            <ButtonComponent>Login</ButtonComponent>                
                
            </template>
        </v-app-bar>
        
    </v-layout>
    <!-- <router-view>
    </router-view> -->
</template>


<script setup lang="ts">
import ButtonComponent from "@/components/ButtonComponent.vue";
import { eventBus } from '@/data/EventBus';

function toggleSideBar() {
    eventBus.emit('toggle-sidebar')
}
</script>
<template>
    <v-app-bar>
        <template v-slot:prepend>
            <button-component variant="text" :rounded="false" flat @click="toggleSideBar()">
                <v-icon size="x-large">
                    mdi-menu
                </v-icon>
            </button-component>
        </template>
        <v-app-bar-title>Keeper</v-app-bar-title>

    </v-app-bar>
</template>
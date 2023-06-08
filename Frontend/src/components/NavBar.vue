<script setup lang="ts">
import ButtonComponent from "@/components/ButtonComponent.vue";
import { eventBus } from '@/data/EventBus';

</script>
<template>
    <v-app-bar>
        <template v-slot:prepend>
            <button-component variant="text" :rounded="false" flat class="d-block d-sm-none"
                @click="eventBus.emit('toggle-sidebar')">
                <v-icon size="x-large">
                    mdi-menu
                </v-icon>
            </button-component>
        </template>
        <v-app-bar-title>Keeper</v-app-bar-title>

    </v-app-bar>
</template>
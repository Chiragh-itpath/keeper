<script setup lang="ts">
import ButtonComponent from "@/components/ButtonComponent.vue";
import { eventBus } from '@/data/EventBus';
import { ref, type Ref, watch } from 'vue';
import { useRouter } from 'vue-router';
const isHome: Ref<boolean> = ref(true);
const router = useRouter();
watch(() => router.currentRoute.value.fullPath, (newPath) => {
    isHome.value = newPath == '/'
})
function toggleSideBar() {
    eventBus.emit('toggle-sidebar')

}
</script>
<template>
    <v-app-bar>
        <template v-slot:prepend>
            <button-component variant="text" :rounded="false" flat v-if="!isHome" @click="toggleSideBar()">
                <v-icon size="x-large">
                    mdi-menu
                </v-icon>
            </button-component>
        </template>
        <v-app-bar-title>Keeper</v-app-bar-title>

    </v-app-bar>
</template>
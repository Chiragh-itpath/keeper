<script setup lang="ts">
import { reactive } from 'vue';
import { eventBus } from '@/data/EventBus';
import { useUserStore } from '@/stores/UserStore';
let {logout} =useUserStore()
const state = reactive({
    navigationBar: true
});
eventBus.on('toggle-sidebar', () => {
    state.navigationBar = !state.navigationBar
})
</script>
<template>
    <v-navigation-drawer v-model="state.navigationBar" color="primary">
        <slot></slot>
        <template v-slot:append>
          <div class="pa-2">
            <v-btn block @click="logout">
              Logout
            </v-btn>
          </div>
        </template>
    </v-navigation-drawer>
</template>
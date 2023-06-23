<script setup lang="ts">
import { reactive } from 'vue'
import { eventBus } from '@/data/EventBus'
const state = reactive({
  navigationBar: true
})
eventBus.on('toggle-sidebar', () => {
  state.navigationBar = !state.navigationBar
})
</script>
<template>
  <v-navigation-drawer v-model="state.navigationBar" color="primary">
    <slot></slot>
  </v-navigation-drawer>
</template>

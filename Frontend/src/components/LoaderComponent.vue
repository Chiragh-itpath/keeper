<script setup lang="ts"></script>

<template>
  <v-progress-circular indeterminate color="primary" size="x-large"></v-progress-circular>
</template>

<style scoped>
.v-progress-circular {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  z-index: 999;
}
</style>

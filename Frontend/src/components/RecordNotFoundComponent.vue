<script setup lang="ts">
const props=withDefaults(
  defineProps<{
    icon:string,
    title:string
  }>(),{
    icon:'mdi-note-remove',
    title:'Record Not Found'
  }
)
</script>
<template>
  <v-row class="text-dark text-center d-flex justify-center align-center">
    <div class="bg-blue-grey-lighten-5 ma-10 pa-10 rounded-xl">
      <v-col cols="12">
        <v-icon size="150" color="primary">{{ props.icon }}</v-icon>
      </v-col>
      <v-col cols="12" class="text-h4 text-primary">{{props.title}}</v-col>
    </div>
  </v-row>
</template>

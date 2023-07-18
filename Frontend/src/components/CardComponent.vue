<script setup lang="ts">
import type { Tvariant } from '@/type/variants'
const props = withDefaults(
  defineProps<{
    variant?: Tvariant,
    backgroundColor?:string
  }>(),
  {
    variant: 'elevated',
    backgroundColor:''
  }
)
</script>

<template>
  <v-card :variant="props.variant" :rounded="true" elevation="12">
    <div>
      <v-card-title :class="`bg-${props.backgroundColor} text-white text-capitalize text-center`">
        <slot name="title"> </slot>
      </v-card-title>
      <v-card-subtitle>
        <slot name="subtitle"> </slot>
      </v-card-subtitle>
      <v-card-text>
        <slot name="text"> </slot>
      </v-card-text>
      <v-card-actions>
        <slot name="actions"></slot>
      </v-card-actions>
    </div>
    <div>
      <slot name="image"></slot>
    </div>
  </v-card>
</template>

<script setup lang="ts">
import type { Tvariant } from '@/type/variants';
const props = withDefaults(defineProps<{
    rounded?: boolean,
    variant?: Tvariant,
    icon?: string
}>(), {
    rounded: true,
    variant: "outlined",
    icon: 'mdi-plus'
})
</script>
<template>
    <v-btn :rounded="props.rounded" color="primary" :variant="props.variant" :icon="props.icon" >
        <slot></slot>
        
    </v-btn>
</template>
<style>
.v-btn {
    text-transform: capitalize;
    font-size: medium;
}
</style>
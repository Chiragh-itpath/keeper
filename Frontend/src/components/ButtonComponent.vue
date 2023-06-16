<script setup lang="ts">
import type { Tvariant } from '@/type/variants';
const props = withDefaults(defineProps<{
    rounded?: boolean,
    variant?: Tvariant,
    width: string
}>(), {
    rounded: true,
    variant: "outlined",
    width: "100"
})
</script>
<template>
    <v-btn :rounded="props.rounded" color="primary" :variant="props.variant" width="100">
        <slot></slot>
    </v-btn>
</template>
<style>
.v-btn {
    text-transform: capitalize;
    font-size: medium;
}
</style>
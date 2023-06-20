<script setup lang="ts">
import type { Tvariant } from '@/type/variants';
const props = withDefaults(defineProps<{
    rounded?: boolean,
    variant?: Tvariant,
    minWidth: string,
    color:string
}>(), {
    rounded: true,
    variant: "outlined",
    minWidth: "100",
    color:"primary"
})
</script>
<template>
    <v-btn :rounded="props.rounded" :color="props.color" :variant="props.variant" :min-width="props.minWidth">
        <slot></slot>
    </v-btn>
</template>
<style>
.v-btn {
    text-transform: capitalize;
    font-size: medium;
}
</style>
<script setup lang="ts">
import type { Tvariant } from '@/type/variants';
const props = withDefaults(defineProps<{
    rounded: boolean,
    variant: Tvariant
}>(),{
    rounded: true,
    variant: "outlined"
})
</script>
<template>
    <v-btn :rounded="props.rounded" class="px-5" color="primary" :variant="props.variant">
        <slot></slot>
    </v-btn>
</template>
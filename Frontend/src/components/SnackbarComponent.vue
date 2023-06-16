<script setup lang="ts">
import type { Tvariant } from '@/type/variants';
const props = withDefaults(defineProps<{
    variant?: Tvariant
    location?:any,
    error: boolean
}>(), {
    variant: 'elevated',
    location:'bottom right',
    error: false
});
</script>
<template>
    <v-snackbar :timeout="4000"  :variant="props.variant" :location="props.location" :color="error ? 'red-darken-3' : '#1B5E20'" >
       <slot></slot>
    </v-snackbar>
</template>
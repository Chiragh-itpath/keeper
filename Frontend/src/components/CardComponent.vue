<script setup lang="ts">
import type { Tvariant } from '@/type/variants';
const props = withDefaults(defineProps<{
    variant?: Tvariant
}>(), {
    variant: 'elevated'
});
</script>

<template>
<<<<<<< HEAD
    <v-card :variant="props.variant" :rounded="true">    
            <v-card-title class="bg-lightenTeal text-white text-capitalize">
=======
    <v-card :variant="props.variant" :rounded="true">
        <div>
            <v-card-title>
>>>>>>> b81059fdc8a5e13bca3ab9b09963365c3df96085
                <slot name="title">
                </slot>
            </v-card-title>
            <v-card-subtitle>
                <slot name="subtitle">
                </slot>
            </v-card-subtitle>
            <v-card-text>
                <slot name="text">
                </slot>
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
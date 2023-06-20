<script setup lang="ts">
import type { Tvariant } from '@/type/variants';
const props = withDefaults(defineProps<{
    variant?: Tvariant
}>(), {
    variant: 'elevated'
});
</script>

<template>
    <v-card :variant="props.variant" :rounded="true">
        <div>
            <v-card-title class="bg-lightenTeal text-white text-capitalize text-center">
                <slot name="title">
                </slot>
            </v-card-title>
            <v-card-subtitle>
                <slot name="subtitle">
                </slot>
            </v-card-subtitle>
                <slot>
                </slot>    
            <v-card-actions>
                <slot name="actions"></slot>
            </v-card-actions>
        </div>
        <div>
            <slot name="image"></slot>
        </div>
    </v-card>
</template>
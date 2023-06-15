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
            <v-card-title>
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
        </div>
        <div>
            <slot name="image"></slot>
        </div>
    </v-card>
</template>
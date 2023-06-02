<script setup lang="ts">
const props = withDefaults(defineProps<{
    title: string,
    hover: boolean,
    color: string
}>(),{
    title: '',
    hover: true,
    color: 'teal-lighten-2'
}); 
</script>
<template>
    <v-hover>
        <template v-slot:default="{ isHovering, props }">
            <v-btn v-bind="props" class="ms-11 ma-5 mt-5 font-weight-bold " size="large" rounded variant="outlined"
                :class="{ 'bg-teal-lighten-2': isHovering && hover, 'text-teal-lighten-2': !isHovering || !hover,  }">
                Get Started
            </v-btn>
        </template>
    </v-hover>
</template>
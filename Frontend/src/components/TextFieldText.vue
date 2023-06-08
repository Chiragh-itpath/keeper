<script setup lang="ts">
import { ref } from 'vue';
import { requiredRule } from '@/data/ValidationRules';
const props = withDefaults(defineProps<{
    prependIcon: string
    label: string
}>(), {
    prependIcon: '',
    label: ''
}) 
</script>

<template>
    <v-text-field :label="props.label" type="text"
        :rules="[requiredRule]"
        :prepend-inner-icon="props.prependIcon"
        clearable
        variant="outlined"
    ></v-text-field>
</template>
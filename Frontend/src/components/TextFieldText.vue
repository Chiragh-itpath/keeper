<script setup lang="ts">
import { ref } from 'vue';
import { requiredRule } from '@/data/ValidationRules';
const props = withDefaults(defineProps<{
    prependIcon: string
    label: string
    isRequired:boolean
}>(), {
    prependIcon: '',
    label: '',
    isRequired:true
}) 
</script>

<template>
    <v-text-field :label="props.label" type="text"
        :rules="[isRequired?requiredRule:true]"
        :prepend-inner-icon="props.prependIcon"
        clearable
        variant="outlined"
        color="primary"
        
    ></v-text-field>
</template>
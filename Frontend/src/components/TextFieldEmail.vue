<script setup lang="ts">
import { ref } from 'vue';

const props = defineProps({
    
    isRequired: {
        type: Boolean,
        default: true
    },
    label: {
        type: String,
        required: true
    }
})
const requiredRule = (val: string) => val.trim()=="" ? "Field is Required!" : true
const emailRules = (value: any) => /.+@.+\..+/.test(value) ? true : 'E-mail must be valid.'
</script>

<template>
    <v-text-field :label="props.label" type="email"
        :rules="[requiredRule,emailRules]"
        prepend-inner-icon="mdi-email"
        clearable
        variant="outlined"
    ></v-text-field>
</template>
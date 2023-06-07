<script setup lang="ts">
import type { Ref } from 'vue';
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
const contactRules = (value : string) => /^[0-9]{10}$/.test(value) ? true : 'Contact number must be valid'
let rulArr = ref([])
</script>

<template>
    <v-text-field :label="props.label" type="text"
        :rules="[requiredRule,contactRules]"
        prepend-inner-icon="mdi-account-box"
        clearable
        :counter="10" :maxlength="10"
        variant="outlined"
    ></v-text-field>
</template>
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
const showPwd = ref(false)
const requiredRule = (val: string) => val.trim()=="" ? "Field is Required!" : true
const passwordRule = (val: string) => val.length < 8 ? "At least 8 characters!" : true
</script>

<template>
    <v-text-field :label="props.label" :type="showPwd ? 'text' : 'password'"
        :rules="[requiredRule,passwordRule]"
        prepend-inner-icon="mdi-lock"
        :append-inner-icon="showPwd ? 'mdi-eye' : 'mdi-eye-off'"
        @click:append-inner="showPwd = !showPwd"
        variant="outlined"
    ></v-text-field>
</template>
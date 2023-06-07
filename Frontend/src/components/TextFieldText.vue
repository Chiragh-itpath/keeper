<script setup lang="ts">
import { ref } from 'vue';

const props = defineProps({
    
    isRequired: {
        type: Boolean,
        default: true
    },
    prependIcon:{
        type: String,
        default:""
    },
    label: {
        type: String,
        required: true
    }
})

const requiredRule = (val: string) => val.trim()=="" ? "Field is Required!" : true
function rulesFun() {
    let rulArr= []
    if (props.isRequired)
        rulArr.push(requiredRule)
    return rulArr
}
</script>

<template>
    <v-text-field :label="props.label" type="text"
        :rules="rulesFun()"
        :prepend-inner-icon="props.prependIcon"
        clearable
        variant="outlined"
    ></v-text-field>
</template>
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
const contactRules = (value : string) => /^[0-9]{10}$/.test(value) || value == '' ? true : 'Contact number must be valid'
const emit = defineEmits(['updatedValue']); 
let rulArr = ref([])
function rulesFun() {
   
    
    if (props.isRequired){
        rulArr.value.push(requiredRule)
    }
    
}
const updateValue = (event: InputEvent) => {
    rulArr.value.push(contactRules)
    emit('updatedValue', (event.target as HTMLInputElement).value);
}
</script>

<template>
    
    <v-text-field :label="props.label" type="text"
        :rules="rulArr"
        prepend-inner-icon="mdi-account-box"
        clearable
        :counter="10" :maxlength="10"
        @input="updateValue"
        variant="outlined"
        ></v-text-field>
</template>
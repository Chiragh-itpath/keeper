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
const emit = defineEmits(['updatedValue']);
function rulesFun() {
    let rulArr= []
    
    if (props.isRequired)
        rulArr.push(requiredRule)
        
    rulArr.push(emailRules)
    return rulArr

}
const updateValue = (event: InputEvent) => {
    emit('updatedValue', (event.target as HTMLInputElement).value);
}
</script>

<template>
    
    <v-text-field :label="props.label" type="email"
        :rules="rulesFun()"
        prepend-inner-icon="mdi-email"
        clearable
        @input="updateValue"
        variant="outlined"
        ></v-text-field>
</template>
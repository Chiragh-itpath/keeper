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
const emit = defineEmits(['updatedValue']);
function rulesFun() {
    let rulArr= []
    
    if (props.isRequired)
        rulArr.push(requiredRule)
        
    rulArr.push(passwordRule)
    return rulArr

}
const updateValue = (event: InputEvent) => {
    emit('updatedValue', (event.target as HTMLInputElement).value);
}
</script>

<template>
    
    <v-text-field :label="props.label" :type="showPwd ? 'text' : 'password'"
        :rules="rulesFun()"
        prepend-inner-icon="mdi-lock"
        :append-inner-icon="showPwd ? 'mdi-eye' : 'mdi-eye-off'"
        @click:append-inner="showPwd = !showPwd"
        @input="updateValue"
        variant="outlined"
        ></v-text-field>
</template>
<script setup lang="ts">
import type { Ref } from 'vue';
import { ref } from 'vue';

const props = defineProps({
    textType: {
        type: String,
        default: 'text'
    },
    isRequired: {
        type: Boolean,
        default: false
    },
    isContact:{
        type:Boolean,
        default: false
    },
    
    prependIcon: {
        type: String,
        required: false
    },
    label: {
        type: String,
        required: true
    }
})

function rulesFun() {
    let rulArr= []
    if (props.isRequired)
        rulArr.push(requiredRule)

    if (props.textType == 'password')
        rulArr.push(passwordRule)

    if (props.textType == 'email')
        rulArr.push(emailRules)

    if(props.isContact){
        rulArr.push(contactRules)
    }
    
    console.log(rulArr);
    return rulArr

}
const showPwd = ref(false)
const requiredRule = (val: string) => val.trim()=="" ? "Field is Required!" : true
const emailRules = (value: any) => /.+@.+\..+/.test(value) ? true : 'E-mail must be valid.'
const passwordRule = (val: string) => val.length < 8 ? "At least 8 characters!" : true
const contactRules = (value : string) => /^[0-9]{10}$/.test(value) || value == '' ? true : 'Contact number must be valid'
const userNameRules = (value: string) => /^[a-zA-Z ]{2,30}$/.test(value) ? true : 'Username must be valid.'
const emit = defineEmits(['updatedValue']);

const updateValue = (event: InputEvent) => {
    emit('updatedValue', (event.target as HTMLInputElement).value);
}

</script>

<template>
    
    <v-text-field :label="props.label" :type="props.textType == 'password' ? showPwd ? 'text' : 'password' : props.textType"
        :append-inner-icon="props.textType == 'password' ? showPwd ? 'mdi-eye' : 'mdi-eye-off' : ''" :rules="rulesFun()"
        :prepend-inner-icon="props.prependIcon" @click:append-inner="showPwd = !showPwd"
        :clearable="props.textType == 'password' ? false : true" variant="outlined"
        @input="updateValue"
        ></v-text-field>
</template>
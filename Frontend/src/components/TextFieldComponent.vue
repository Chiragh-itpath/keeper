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

    console.log(rulArr);
    return rulArr

}
const showPwd = ref(false)
const requiredRule = (val: string) => val.trim()=="" ? "Field is Required!" : true
const emailRules = (value: any) => /.+@.+\..+/.test(value) ? true : 'E-mail must be valid.'
const noRule = (val: string) => true
const passwordRule = (val: string) => val.length < 8 ? "At least 8 characters!" : true

const emit = defineEmits(['updatedValue']);

const updateValue = (event: InputEvent) => {
    emit('updatedValue', (event.target as HTMLInputElement).value);
}

</script>

<template>
    
    <v-text-field :label="props.label" :type="props.textType == 'password' ? showPwd ? 'text' : 'password' : props.textType"
        :append-icon="props.textType == 'password' ? showPwd ? 'mdi-eye' : 'mdi-eye-off' : ''" :rules="rulesFun()"
        :prepend-icon="props.prependIcon" @click:append="showPwd = !showPwd"
        :clearable="props.textType == 'password' ? false : true"
        @input="updateValue"
        ></v-text-field>
</template>
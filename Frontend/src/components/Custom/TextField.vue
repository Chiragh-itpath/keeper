<script lang="ts" setup>
import {
    contactRules,
    emailRules,
    numberRules,
    otpRules,
    passwordRule,
    requiredRule
} from '@/data/ValidationRules'
import { ref, type Ref } from 'vue'

type TRule = (arg: string) => boolean | string

const Props = withDefaults(
    defineProps<{
        label?: string
        color?: string
        placeholder?: string
        isRequired?: boolean
        isEmail?: boolean
        isContact?: boolean
        isPassword?: boolean
        isNumber?: boolean
        isOtp?: boolean
        icon?: string
        ValidationRules?: TRule[],
        errorMessages?: string[]
    }>(),
    {
        label: '',
        color: 'primary',
        placeholder: '',
        isRequired: false,
        isEmail: false,
        isContact: false,
        isPassword: false,
        isNumber: false,
        isOtp: false,
        icon: '',
    }
)
const error: Ref<boolean> = ref(false)
let Rules: TRule[] = []
let type: Ref<string> = ref(Props.isEmail ? 'email' : Props.isPassword ? 'password' : 'text')

let isPasswordVisible: Ref<boolean> = ref(false)

if (Props.isRequired) Rules.push(requiredRule)

if (Props.isContact) Rules.push(contactRules)

if (Props.isEmail) Rules.push(emailRules)

if (Props.isPassword) Rules.push(passwordRule)

if (Props.isNumber) Rules.push(numberRules)
if (Props.isOtp) {
    Rules = []
    Rules.push(requiredRule)
    Rules.push(otpRules)
    type.value = 'number'
}
Rules.push(...(Props.ValidationRules || []))

const changeVisibility = (): void => {
    isPasswordVisible.value = !isPasswordVisible.value
    type.value = isPasswordVisible.value ? 'text' : 'password'
}
if (Props.errorMessages) {
    if (Props.errorMessages.length > 0) {
        error.value = true
    }
}
</script>
<template>
    <v-text-field :label="Props.label" :type="type" :color="Props.color" :rules="Rules" :prepend-inner-icon="Props.icon"
        :append-inner-icon="!isPassword ? '' : isPasswordVisible ? 'mdi-eye' : 'mdi-eye-off'"
        @click:append-inner="changeVisibility" @update="() => { }" :placeholder="placeholder"
        :error-messages="errorMessages" :error="error">
    </v-text-field>
</template>

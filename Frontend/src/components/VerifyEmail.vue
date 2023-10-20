<script setup lang="ts">
import { ref, type Ref } from 'vue'
import { storeToRefs } from 'pinia'
import { useRouter } from 'vue-router'
import TextField from '@/components/Custom/TextField.vue'
import { UserStore, AccountStore } from '@/stores'
import { RouterEnum } from '@/Models/enum'


const { email } = storeToRefs(AccountStore())


const form = ref()
const errorMessages: Ref<string[]> = ref([])
const { CheckEmail } = UserStore()

const router = useRouter()

const validateEmail = async () => {
    errorMessages.value = []
    const { valid } = await form.value.validate()
    if (!valid) return
    const res = await CheckEmail(email.value)
    if (!res) {
        errorMessages.value.push('Email does not exist')
        return
    }
    router.push({ name: RouterEnum.VERIFY_OTP })
}
</script>
<template>
    <v-form ref="form" validate-on="submit">
        <div>
            <text-field v-model="email" label="Email" placeholder="Enter your Email" is-required is-email
                :error-messages="errorMessages" />
            <div class="text-center">
                <v-btn color="primary" @click="validateEmail">
                    Verify Email
                </v-btn>
            </div>
        </div>
    </v-form>
</template>
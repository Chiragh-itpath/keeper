<script setup lang="ts">
import { ref, type Ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import TextField from '@/components/Custom/TextField.vue'
import { AccountStore } from '@/stores'
import { storeToRefs } from 'pinia'
import { RouterEnum } from '@/Models/enum'


const otp: Ref<number | undefined> = ref()
const otpFromServer: Ref<number | undefined> = ref()
const errorMessages: Ref<string[]> = ref([])
const { email } = storeToRefs(AccountStore())
const { fetchOtp } = AccountStore()
const form = ref()
const router = useRouter()

const VerifyOTP = async () => {
    errorMessages.value = []
    const { valid } = await form.value.validate()
    if (!valid) return
    if (otp.value != otpFromServer.value) {
        errorMessages.value.push('Wrong otp')
        return
    }
    router.push({ name: RouterEnum.PASSWORD_RESET })
}
onMounted(async () => {
    if (email.value == '') {
        router.push({ name: RouterEnum.VERIFY_EMAIL })
        return
    }
    otpFromServer.value = await fetchOtp(email.value)
})
</script>
<template>
    <v-form ref="form" validate-on="submit"> 
        <p class="ma-2 text-grey">Please check your mail for OTP</p>
        <text-field label="OTP" placeholder="Enter 6 Digit OTP" is-otp v-model="otp" :error-messages="errorMessages" />
        <div class="text-center">
            <v-btn color="primary" @click="VerifyOTP">
                Verify OTP
            </v-btn>
        </div>
    </v-form>
</template>
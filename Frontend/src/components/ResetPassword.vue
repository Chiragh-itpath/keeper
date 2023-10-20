<script setup lang="ts">
import { ref, type Ref, onMounted } from 'vue'
import { useRouter } from 'vue-router'
import { storeToRefs } from 'pinia'
import { AccountStore } from '@/stores'
import TextField from '@/components/Custom/TextField.vue'
import { RouterEnum } from '@/Models/enum'

const form = ref()

const errorMessages: Ref<string[]> = ref([])
const Password: Ref<string> = ref('')
const confirmPassword: Ref<string> = ref('')
const router = useRouter()
const { email } = storeToRefs(AccountStore())
const { PasswordReset } = AccountStore()

const ChangePassWord = async () => {
    errorMessages.value = []
    const { valid } = await form.value.validate()
    if (!valid) return
    if (Password.value != confirmPassword.value) {
        errorMessages.value.push('Password and confirm Password must be same')
        return
    }
    await PasswordReset({
        email: email.value,
        password: Password.value
    })
    router.push({ name: RouterEnum.LOGIN })

}

onMounted(() => {
    if (email.value == '') {
        router.go(-1)
    }
})
</script>
<template>
    <v-form ref="form" validate-on="submit">
        <text-field label="Password" v-model="Password" placeholder="Enter new Password" is-required is-password />
        <text-field label="Confirm Password" v-model="confirmPassword" is-required is-password
            placeholder="Enter confirm Password" :error-messages="errorMessages" />
        <div class="d-flex justify-center pa-4">
            <v-btn color="primary" @click="ChangePassWord">Change Password</v-btn>
        </div>
    </v-form>
</template>
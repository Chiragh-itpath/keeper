<script setup lang="ts">
import { ref, reactive } from 'vue'
import { RouterEnum } from '@/Models/enum'
import TextField from '@/components/Custom/TextField.vue'
import { AccountStore } from '@/stores'
import type { IRegister } from '@/Models/UserModels'
const { registerUser } = AccountStore()

const form = ref()
const SignUpForm = reactive<IRegister>({
    userName: '',
    email: '',
    contact: '',
    password: '',
    confirmPassword: ''
})

const checkPassword = (): boolean | string => {
    return SignUpForm.password == SignUpForm.confirmPassword
        ? true
        : 'Password and Confirm Password must be same'
}

async function register(): Promise<void> {
    const { valid } = await form.value.validate()

    if (!valid) return

    await registerUser(SignUpForm)
}

</script>
<template>
    <div class="bg"></div>
    <v-container fill-height fluid class="hide-scrollerbar">
        <v-row justify="center" align-content="center" class="h-screen">
            <v-col cols="12" sm="12" md="6" lg="4" >
                <v-card class="pa-4 elevation-12 rounded-xl" >
                    <v-card-title class="text-center mt-5">
                        <h2 class="text-teal">Keeper</h2>
                        Sign Up
                    </v-card-title>
                    <v-card-subtitle class="text-center mb-5">
                        to continue to Keeper
                    </v-card-subtitle>
                    <v-form @submit.prevent="register" ref="form" validate-on="submit">
                        <div class="mx-5">
                            <text-field v-model="SignUpForm.userName" label="Username" icon="mdi-account" is-required />
                            <text-field v-model="SignUpForm.email" label="Email" icon="mdi-email" is-required is-email />
                            <text-field v-model="SignUpForm.contact" label="Contact" icon="mdi-account" is-required
                                is-contact />
                            <text-field v-model="SignUpForm.password" label="Password" icon="mdi-lock" is-required
                                is-password />
                            <text-field v-model="SignUpForm.confirmPassword" label="Confirm Password" icon="mdi-lock"
                                is-required is-password :-validation-rules="[checkPassword]" />
                        </div>

                        <v-card-actions>
                            <div class="d-flex flex-column justify-center mx-auto">
                                <v-btn type="submit" flatcolor="#5865f2" rounded="lg" size="large" variant="flat"
                                    color="teal" class="mt-4">Sign Up</v-btn>

                                <div class="mt-5">
                                    Already have an account?
                                    <router-link :to="{ name: RouterEnum.LOGIN }">Sign In</router-link>
                                </div>
                            </div>
                        </v-card-actions>
                    </v-form>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>

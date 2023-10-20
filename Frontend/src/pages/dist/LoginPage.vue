<script setup lang="ts">
import { ref, reactive } from 'vue'
import { RouterEnum } from '@/Models/enum'
import type { ILogin } from '@/Models/UserModels'
import TextField from '@/components/Custom/TextField.vue'
import { AccountStore } from '@/stores'
import type { Ref } from 'vue'

const { loginUser } = AccountStore()
const errorMessage: Ref<string[]> = ref([])

const form = ref()
const loginForm = reactive<ILogin>({
    email: '',
    password: ''
})

const login = async (): Promise<void> => {
    const { valid } = await form.value.validate()
    if (!valid) return
    await loginUser(loginForm)
}
</script>
<template>
    <div class="bg"></div>
    <v-container fill-height fluid>
        <v-row justify="center" align-content="center" class="h-screen">
            <v-col cols="12" lg="4" sm="12">
                <v-card elevation="10" class="rounded-xl">
                    <v-card-title class="text-center mt-5">
                        <h2 class="text-teal">Keeper</h2>
                        Login
                    </v-card-title>
                    <v-card-subtitle class="text-center">
                        to continue to Keeper
                    </v-card-subtitle>
                    <v-card-text>
                        <v-form ref="form" @submit.prevent="login" validate-on="submit">
                            <div class="mx-5">
                                <text-field v-model="loginForm.email" label="Email" is-required is-email icon="mdi-email" />
                                <text-field v-model="loginForm.password" label="Password" is-required is-password
                                    icon="mdi-lock" :error-messages="errorMessage" />
                            </div>
                            <div class="text-right">
                                <router-link :to="{ name: RouterEnum.VERIFY_EMAIL }">
                                    Forgot Password?
                                </router-link>
                            </div>
                            <v-card-actions>
                                <div class="d-flex flex-column justify-center mx-auto">
                                    <v-btn type="submit" flatcolor="#5865f2" rounded="lg" size="large" variant="flat"
                                        color="teal" class="mt-4">
                                        Login
                                    </v-btn>
                                    <div class="mt-5">
                                        New User?
                                        <router-link :to="{ name: RouterEnum.SIGNUP }">
                                            Create an account
                                        </router-link>
                                    </div>
                                </div>
                            </v-card-actions>
                        </v-form>
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>
<style scoped>
.blur {
    opacity: 0.2;
}
</style>

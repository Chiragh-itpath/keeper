<script setup lang="ts">
import { RouterEnum } from '@/enum/RouterEnum';
import { ref, reactive } from 'vue';
import TextFieldEmail from "@/components/TextFieldEmail.vue";
import TextFieldPassword from "@/components/TextFieldPassword.vue";
import type { ILogin } from '@/Models/LoginModel';
import { useAccountStore } from "@/stores/AccountStore";

const { loginUser } = useAccountStore()
const form = ref()
const state = reactive({
    email: "",
    password: ""
})
async function login(): Promise<void> {
    const { valid } = await form.value.validate();
    if (!valid) return
    const user: ILogin = {
        Email: state.email,
        Password: state.password
    }
    const response = await loginUser(user);
    console.log(response);
}

</script>
<template>
    <v-app>
        <v-main>
            <v-container fill-height fluid>
                <v-row justify="center" align-content="center">
                    <v-col cols="12" lg="4" sm="12">
                        <v-card class="elevation-12 my-auto">
                            <v-card-title class="text-center mt-5">
                                <h2 class="text-teal">Keeper</h2>
                                Login
                            </v-card-title>
                            <v-card-subtitle class="text-center">
                                to continue to Keeper
                            </v-card-subtitle>
                            <v-card-text>
                                <v-form ref="form" @submit.prevent="login">
                                    <TextFieldEmail v-model="state.email" label="Email" color="primary" />
                                    <TextFieldPassword v-model="state.password" label="Password" color="primary" />
                                    <div class="text-right">
                                        <router-link :to="{ name: RouterEnum.FORGOT_PASSWORD }">Forgot
                                            Password?</router-link>
                                    </div>
                                    <v-card-actions>
                                        <div class="d-flex flex-column justify-center mx-auto">
                                            <v-btn type="submit" flatcolor="#5865f2" rounded="lg" size="large"
                                                variant="flat" color="teal" class="mt-4">Login</v-btn>
                                            <div class="mt-5">
                                                New User?
                                                <router-link :to="{ name: RouterEnum.SIGNUP }">Create an
                                                    account</router-link>
                                            </div>
                                        </div>
                                    </v-card-actions>
                                </v-form>
                            </v-card-text>
                        </v-card>
                    </v-col>
                </v-row>
            </v-container>
        </v-main>
    </v-app>
</template>
<style>
.v-messages__message {
    margin-bottom: 20px;
}
</style>
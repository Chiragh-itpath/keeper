<script setup lang="ts">
import TextFieldComponent from '@/components/TextFieldComponent.vue';
import { RouterEnum } from '@/enum/RouterEnum';
import { ref, type Ref } from 'vue';
import TextFieldEmail from "@/components/TextFieldEmail.vue";
import TextFieldPassword from "@/components/TextFieldPassword.vue";
const email: Ref<string> = ref('')
const password: Ref<string> = ref('')
const form = ref()
// const showPwd: Ref<boolean> = ref(false)
// const requiredRule = (val: string) => val.trim() == "" ? "Field is Required!" : true
// const emailRules = (value: any) => /.+@.+\..+/.test(value) ? true : 'E-mail must be valid.'
// const passwordRule = (val: string) => val.length < 8 ? "At least 8 characters!" : true
async function login() {
    const { valid } = await form.value.validate();
    if (valid) {
        alert("Valid")
        form.value.reset();
    }
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
                                <v-form ref="form" @submit.prevent="login()">
                                    <TextFieldEmail v-model="email" label="Email" />
                                    <TextFieldPassword v-model="password" label="Password" />
                                    <div class="text-right">


                                        <router-link :to="{ name: RouterEnum.FORGOT_PASSWORD }">Forgot Password?</router-link>

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
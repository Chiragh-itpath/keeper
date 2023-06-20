<script setup lang="ts">
import { ref, reactive } from 'vue';
import { RouterEnum } from '@/enum/RouterEnum';
import TextFieldContact from "@/components/TextFieldContact.vue";
import TextFieldEmail from "@/components/TextFieldEmail.vue";
import TextFieldPassword from "@/components/TextFieldPassword.vue";
import TextFieldText from "@/components/TextFieldText.vue";
import { requiredRule } from '@/data/ValidationRules'
import type { IRegister } from "@/Models/RegisterModel";
import { useAccountStore } from '@/stores/AccountStore';
import { StatusType } from '@/enum/StatusType'
import { useRouter } from 'vue-router';
import Snackbar from '@/components/SnackbarComponent.vue'
const { registerUser } = useAccountStore();
const router = useRouter();
const form = ref();
const state = reactive({
    username: "",
    email: "",
    contact: "",
    password: "",
    confirmPassword: "",
    emailExists: false,
    emailError: "",
    isDisable: false,
    showSnackbar: false,
    SnackbarMessage: "",
    serverError: false
})
async function register(): Promise<void> {
    const { valid } = await form.value.validate();
    if (!valid)
        return
    state.isDisable = true;
    const user: IRegister = {
        UserName: state.username,
        Email: state.email,
        Contact: state.contact,
        Password: state.password,
        ConfirmPassword: state.confirmPassword
    }
    const response = await registerUser(user);
    try {
        state.emailExists = false;
        if (response.data.statusName != StatusType.SUCCESS) {
            state.emailExists = true
            state.emailError = response.data.message
            state.showSnackbar = true
            state.serverError=true
        }
        else {
            state.SnackbarMessage = response.data.message
            state.emailExists = false
            state.showSnackbar = true
            state.serverError=false
            form.value.reset()
            setTimeout(() => {
                router.push({ name: RouterEnum.LOGIN })
            }, 1000);
        }
    }
    catch (e) {
        state.serverError = true
        state.showSnackbar = true;
        state.SnackbarMessage = "Internal Server Error"
    }
    finally {
        state.isDisable = false
    }
}
function validatePassword() {
    if (state.password !== state.confirmPassword) {
        return false;
    }
    return true;
}
</script>
<template>
    <v-app>
        <v-main class="d-flex justify-center align-center">
            <v-col cols="12" sm="12" md="6" lg="4" xl="3" xxl="2" class="mx-auto">
                <v-card class="pa-4 elevation-12">
                    <v-card-title class="text-center mt-5">
                        <h2 class="text-teal">Keeper</h2>
                        Sign Up
                    </v-card-title>
                    <v-card-subtitle class="text-center mb-5">
                        to continue to Keeper
                    </v-card-subtitle>
                    <v-form @submit.prevent="register" ref="form">
                        <TextFieldText v-model="state.username" label="Username" prepend-icon="mdi-account"
                            color="primary" />
                        <TextFieldContact label="Contact" :is-required="false" v-model="state.contact" color="primary" />
                        <TextFieldEmail v-model="state.email" label="Email" color="primary" />
                        <TextFieldPassword v-model="state.password" label="Password" color="primary"
                            :error-messages="state.emailExists ? state.emailError : ''" />
                        <TextFieldPassword v-model="state.confirmPassword" label="Confirm Password" color="primary"
                            :rules="[requiredRule, validatePassword() ? true : 'Password not match!']" />
                        <v-card-actions>
                            <div class="d-flex flex-column justify-center mx-auto">
                                <Snackbar v-model="state.showSnackbar" :error="state.serverError">
                                    <v-icon v-if="state.serverError">mdi-alert</v-icon>
                                    <v-icon v-else>mdi-check</v-icon>
                                    {{ state.SnackbarMessage }}
                                </Snackbar>
                                <v-btn type="submit" flatcolor="#5865f2" rounded="lg" size="large" variant="flat"
                                    color="teal" class="mt-4" :disabled="state.isDisable">Sign Up</v-btn>
                                <div class="mt-5">
                                    Already have an account? <router-link :to="{ name: RouterEnum.LOGIN }">Sign
                                        In</router-link>
                                </div>
                            </div>
                        </v-card-actions>
                    </v-form>
                </v-card>
            </v-col>
        </v-main>
    </v-app>
</template>
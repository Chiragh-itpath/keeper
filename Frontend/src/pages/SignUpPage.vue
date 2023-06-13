<script setup lang="ts">
import { ref, reactive } from 'vue';
import { RouterEnum } from '@/enum/RouterEnum';
import TextFieldContact from "@/components/TextFieldContact.vue";
import TextFieldEmail from "@/components/TextFieldEmail.vue";
import TextFieldPassword from "@/components/TextFieldPassword.vue";
import TextFieldText from "@/components/TextFieldText.vue";
import { requiredRule } from '@/data/ValidationRules'
import type { IRegister } from "@/Models/RegisterModel";
import {signup } from "@/Services/AccountService";
const form = ref()
const state = reactive({
    username: "",
    email: "",
    contact: "",
    password: "",
    confirmPassword: "",
    errorMessage: ""
})
async function register(): Promise<void> {
    const user:IRegister ={
        UserName:state.username,
        Email:state.email,
        Contact:state.contact,
        Password:state.password,
        ConfirmPassword:state.confirmPassword
    }
    try {
        signup(user)
    }
    catch (e) {
        console.log(e);
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
                        <TextFieldPassword v-model="state.password" label="Password" color="primary" />
                        <TextFieldPassword v-model="state.confirmPassword" label="Confirm Password" color="primary"
                            :rules="[requiredRule, validatePassword() ? true : 'Password not match!']" />
                        <v-card-actions>
                            <div class="d-flex flex-column justify-center mx-auto">
                                <v-btn type="submit" flatcolor="#5865f2" rounded="lg" size="large" variant="flat"
                                    color="teal" class="mt-4" >Sign Up</v-btn>
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
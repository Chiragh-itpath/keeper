<script setup lang="ts">
import TextFieldComponent from '@/components/TextFieldComponent.vue';
import { RouterEnum } from '@/enum/RouterEnum';
import { ref, type Ref } from 'vue';


const email: Ref<string> = ref('')
const password: Ref<string> = ref('')
const form = ref()
async function login():Promise<void> {
    const { valid } = await form.value.validate();
    if (valid) {
        alert("Valid")
        form.value.reset();
    }
}
</script>
<template>
    
    <v-app>
        <v-main class="d-flex justify-center align-center">
           
                <v-row justify="center" align-content="center" >
                    <v-col cols="12" lg="4" sm="12">
                        <v-card class="elevation-12 my-auto">
                            <v-card-title class="text-center mt-5">
                                <h2 class="text-teal">Keeper</h2>
                                Sign In
                            </v-card-title>
                            <v-card-subtitle class="text-center">
                                to continue to Keeper
                            </v-card-subtitle>
                            <v-card-text>
                                <v-form ref="form" @submit.prevent="login()">
                                            <text-field-component v-model="email" prepend-icon="mdi-email" label="Email" :is-required=true text-type="email" @updatedValue="(val)=>email=val"/>
                                            <text-field-component v-model="password" prepend-icon="mdi-lock" label="Password" :is-required=true text-type="password" @updatedValue="(val)=>password=val"/>
                                    <div class="text-right">
                                        <router-link :to="{name:RouterEnum.ForgotPassword}">Forgot Password?</router-link>   
                                    </div>
                                    <v-card-actions>
                                        <div class="d-flex flex-column justify-center mx-auto">
                                            <v-btn type="submit" flatcolor="#5865f2" rounded="lg" size="large"
                                                variant="flat" color="teal" class="mt-4">Sign In</v-btn>
                                            <div class="mt-5">
                                                New User? <router-link :to="{name:RouterEnum.SignUp}">Create Account</router-link>
                                            </div>
                                        </div>
                                    </v-card-actions>
                                </v-form>
                            </v-card-text>
                        </v-card>
                    </v-col>
                </v-row>
           
        </v-main>
    </v-app>
</template>
<style>
.v-messages__message {
    margin-bottom: 20px;
}
</style>
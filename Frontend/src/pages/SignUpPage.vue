<script setup lang="ts">
import { ref, type Ref, reactive } from 'vue';
import textField from "@/components/TextFieldComponent.vue";
import { RouterEnum } from '@/enum/RouterEnum';
import TextFieldContact from "@/components/TextFieldContact.vue";
import TextFieldEmail from "@/components/TextFieldEmail.vue";
import TextFieldPassword from "@/components/TextFieldPassword.vue";
import TextFieldText from "@/components/TextFieldText.vue";
const form = ref()

const username: Ref<string> = ref('')
const email: Ref<string> = ref('')
const contact: Ref<string> = ref('')
const password: Ref<string> = ref('')
const confirmPassword: Ref<string> = ref('')
async function register(): Promise<void> {
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

                        <TextFieldText v-model="username" label="Username" prepend-icon="mdi-account" />
                        <TextFieldContact label="Contact" :is-required="false" v-model="contact" />
                        <TextFieldEmail v-model="email" label="Email" />
                        <TextFieldPassword v-model="password" label="Password" />
                        <TextFieldPassword v-model="confirmPassword" label="Confirm Password" />
                        

                        <v-card-actions>
                            <div class="d-flex flex-column justify-center mx-auto">
                                <v-btn type="submit" flatcolor="#5865f2" rounded="lg" size="large" variant="flat"
                                    color="teal" class="mt-4">Sign Up</v-btn>
                                <div class="mt-5">
                                    Already have an account? <router-link :to="{ name: RouterEnum.SIGNIN }">Sign
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
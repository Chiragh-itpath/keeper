<script setup lang="ts">
import { ref, type Ref, reactive } from 'vue';
const form = ref()

const username: Ref<string>=ref('')
const email: Ref < string > = ref('')
const contact: Ref<string>=ref('')
const password: Ref < string > = ref('')
const confirmPassword: Ref<string> = ref('')
const passwordShow: Ref<boolean> = ref(false)
const confirmPasswordShow: Ref < boolean > = ref(false)

const requiredRule = (value: string) => value.trim() == "" ? "Field is Required!" : true
const userNameRules = (value: string) => /^[a-zA-Z ]{2,30}$/.test(value) ? true : 'UserName must be valid.'
const emailRules = (value: any) => /.+@.+\..+/.test(value) ? true : 'E-mail must be valid.'
const contactRules = (value : string) => /^[0-9]{10}$/.test(value) || value == '' ? true : 'Contact number must be valid'
const passwordRules = (value: string) => value.length < 8 ? "Password must be contain at least 8 characters!" : true
const confirmPasswordRules = (value:string) => value != password.value ? 'Passwords do not match': true
            
async function register() {
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
                <v-card class="pa-4">
                    <div class="text-center mb-3">
                        <v-avatar size="100" color="teal-lighten-2">
                            <v-icon size="60" color="">mdi mdi-google-keep</v-icon>
                        </v-avatar>
                        <h2 class="indigo--text">SignUp Now!</h2>
                    </div>
                    <v-form @submit.prevent="register" ref="form">
                        <v-card-text>
                            <v-text-field v-model="username" :rules="[requiredRule, userNameRules]" type="text" label="UserName" placeholder="UserName" prepend-inner-icon="mdi-account" required></v-text-field>
                            <v-text-field v-model="email" :rules="[requiredRule, emailRules]" type="email" label="Email" placeholder="Email" prepend-inner-icon="mdi-email" required></v-text-field>
                            <v-text-field v-model="contact" :counter="10" :maxlength="10" :rules="[contactRules]" type="text" label="Contact Number" placeholder="Contact Number" prepend-inner-icon="mdi-account-box"></v-text-field>
                            <v-text-field v-model="password" :rules="[requiredRule, passwordRules]" :type="passwordShow?'text':'password'" label="Password" placeholder="Password" prepend-inner-icon="mdi-lock" :append-icon="passwordShow ? 'mdi-eye':'mdi-eye-off'" @click:append="passwordShow = !passwordShow"
                                required></v-text-field>
                            <v-text-field v-model="confirmPassword" :rules="[requiredRule, confirmPasswordRules]" :type="confirmPasswordShow?'text':'password'" label="Confirm Password" placeholder="Confirm Password" prepend-inner-icon="mdi-key-variant" :append-icon="confirmPasswordShow ? 'mdi-eye':'mdi-eye-off'"
                                @click:append="confirmPasswordShow = !confirmPasswordShow" required></v-text-field>
                        </v-card-text>
                        <v-card-actions class="justify-center">
                            <v-btn type="submit" color="teal-lighten-2" rounded="lg" size="large" variant="flat">
                                <span class="px-5">Sign Up</span>
                            </v-btn>
                        </v-card-actions>
                    </v-form>
                </v-card>
            </v-col>
        </v-main>
    </v-app>
</template>
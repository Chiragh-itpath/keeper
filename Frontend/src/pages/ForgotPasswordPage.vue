<script setup lang="ts">
import TextFieldEmail from "@/components/TextFieldEmail.vue";
import Button from "@/components/ButtonComponent.vue";
import TextFieldOTP from "@/components/TextFieldOTP.vue";
import TextFieldPassword from "@/components/TextFieldPassword.vue";
import { reactive, ref } from "vue";
const form = ref();
const state = reactive({
    email: "",
    otp: "",
    isDisable: false,
    password: "",
    confirmPassword: "",
    show: false
});
async function validateEmail() {
    const { valid } = await form.value.items[0].validate();
    if (!valid)
        return
};
async function SubmitForm() {
    const { valid } = await form.value.validate();
    if (!valid)
        return
    state.show = true;
};
</script>
<template>
    <v-container>
        <div class="text-h5 text-center text-primary">Forgot your password?</div>
        <div class="text-h6 text-center text-grey">Please enter your email to recieve a verification code.</div>
        <v-sheet class="mx-auto v-col-12 v-col-lg-6 v-col-sm-12 v-col-md-6">
            <v-form ref="form">
                <div v-if="state.show">
                    <div class="text-h5 text-center text-primary mb-2">Reset your password</div>
                    <TextFieldPassword label="Enter Password" v-model="state.password" color="primary" class="mb-2">
                    </TextFieldPassword>
                    <TextFieldPassword label="Enter confirm password" v-model="state.confirmPassword" color="primary"
                        class="mb-2"></TextFieldPassword>
                    <div class="text-right">
                        <Button @click="SubmitForm()" :disabled="state.isDisable" class="mb-3" type="submit"
                            variant="elevated">Reset password</Button>
                    </div>
                </div>
                <div v-else>
                    <TextFieldEmail label="Enter email" v-model="state.email" color="primary" />
                    <div class="text-right">
                        <Button class="mb-2" @click="validateEmail()">Send OTP</Button>
                    </div>
                    <TextFieldOTP label="Enter OTP" v-model="state.otp" color="primary" />
                    <div class="text-right">
                        <Button @click="SubmitForm()" :disabled="state.isDisable" class="mb-3">Submit</Button>
                    </div>
                </div>
            </v-form>
        </v-sheet>
</v-container></template>
<script setup lang="ts">
import TextFieldEmail from "@/components/TextFieldEmail.vue";
import Button from "@/components/ButtonComponent.vue";
import TextFieldOTP from "@/components/TextFieldOTP.vue";
import TextFieldPassword from "@/components/TextFieldPassword.vue";
import { reactive, ref } from "vue";
import { useAccountStore } from "@/stores/AccountStore";
import { StatusType } from "@/enum/StatusType";

const { SendOTP } = useAccountStore()
const form = ref();
const state = reactive({
    email: "",
    otp: "",
    isDisable: false,
    password: "",
    confirmPassword: "",
    showResetPwdForm: false,
    showOTPForm: false,
    emailError: false,
    emailErrorMessage: "",
    otpError: false,
    otpErrorMessage: "",
    actualOTP:0
});
async function validateEmail() {
    const { valid } = await form.value.validate();
    if (!valid)
        return

    let otpRes = await SendOTP(state.email)

    if (otpRes.data.statusName != StatusType.SUCCESS) {
        state.emailError = true
        state.emailErrorMessage = otpRes.data.message
    }
    else {
        state.actualOTP=otpRes.data.data.otp
        state.showOTPForm = true
    }
};
async function ValidateOTP() {
    const { valid } = await form.value.validate();
    if (!valid)
        return

    if(state.actualOTP==Number(state.otp))
        state.showResetPwdForm = true;
    else{
        state.otpError=true
        state.otpErrorMessage="Invalid OTP!!"
    }

};
</script>
<template>
    <v-container>
        <v-sheet class="mx-auto v-col-12 v-col-lg-6 v-col-sm-12 v-col-md-6">
            <v-form ref="form">
                <div v-if="state.showResetPwdForm">
                    <div class="text-h5 text-center text-primary mb-2">Reset your password</div>
                    <TextFieldPassword label="Enter Password" v-model="state.password" color="primary" class="mb-2">
                    </TextFieldPassword>
                    <TextFieldPassword label="Enter confirm password" v-model="state.confirmPassword" color="primary"
                        class="mb-2"></TextFieldPassword>
                    <div class="text-right">
                        <Button :disabled="state.isDisable" class="mb-3" type="submit" variant="elevated">Reset
                            password</Button>
                    </div>
                </div>
                <div v-else>
                    <div v-if="!state.showOTPForm">
                        <div class="text-h5 text-center text-primary">Forgot your password?</div>
                        <div class="text-h6 text-center text-grey">Please enter your email to recieve a verification code.
                        </div>
                        <TextFieldEmail label="Enter email" v-model="state.email" color="primary"
                            :error-messages="state.emailError ? state.emailErrorMessage : ''" />
                        <div class="text-right">
                            <Button class="mb-2" @click="validateEmail()">Send OTP</Button>
                        </div>
                    </div>

                    <div v-else>
                        <div class="text-h6 text-grey mb-2">OTP has been send to your email address</div>
                        <TextFieldOTP label="Enter OTP" :error-messages="state.otpError?state.otpErrorMessage:''" placeholder="Enter OTP e.g 435355" v-model="state.otp"
                            color="primary" />
                        <div class="text-right">
                            <Button @click="ValidateOTP()" :disabled="state.isDisable" class="mb-3">Submit</Button>
                        </div>
                    </div>
                </div>
            </v-form>
        </v-sheet>
    </v-container>
</template>
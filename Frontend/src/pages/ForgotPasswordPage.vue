<script setup lang="ts">
import TextFieldEmail from '@/components/TextFieldEmail.vue'
import Button from '@/components/ButtonComponent.vue'
import TextFieldOTP from '@/components/TextFieldOTP.vue'
import TextFieldPassword from '@/components/TextFieldPassword.vue'
import { reactive, ref } from 'vue'
import { useAccountStore } from '@/stores/AccountStore'
import { StatusType } from '@/enum/StatusType'
import type { ILogin } from '@/Models/LoginModel'
import SnackbarComponent from '@/components/SnackbarComponent.vue'
import { RouterEnum } from '@/enum/RouterEnum'
import { useRouter } from 'vue-router'

const router = useRouter()
const { SendOTP, ResetPassword } = useAccountStore()
const form = ref()
const state = reactive({
  email: '',
  otp: '',
  isDisable: false,
  password: '',
  confirmPassword: '',
  showResetPwdForm: false,
  showOTPForm: false,
  emailError: false,
  emailErrorMessage: '',
  otpError: false,
  otpErrorMessage: '',
  actualOTP: 0,
  openSnkbar: false,
  resMessage: '',
  isError: false
})

async function validateEmail(): Promise<void> {
  const { valid } = await form.value.validate()
  if (!valid) return

  let otpRes = await SendOTP(state.email)

  if (otpRes.data.statusName != StatusType.SUCCESS) {
    state.emailError = true
    state.emailErrorMessage = otpRes.data.message
  } else {
    state.actualOTP = otpRes.data.data.otp
    state.showOTPForm = true
  }
}
async function ValidateOTP(): Promise<void> {
  const { valid } = await form.value.validate()
  if (!valid) return

  if (state.actualOTP == Number(state.otp)) state.showResetPwdForm = true
  else {
    state.otpError = true
    state.otpErrorMessage = 'Invalid OTP!!'
  }
}

async function ResetPwd(): Promise<void> {
  let user: ILogin = {
    Email: state.email,
    Password: state.password
  }
  const res = await ResetPassword(user)
  if (res.data.statusName == StatusType.SUCCESS) {
    state.isError = false
    state.resMessage = res.data.message
    state.openSnkbar = true
    setTimeout(() => {
      router.push({ name: RouterEnum.LOGIN })
    }, 1000)
  } else {
    state.resMessage = res.data.message
    state.isError = true
    state.openSnkbar = true
  }
}
function validatePassword() {
  if (state.password !== state.confirmPassword) {
    return false
  }
  return true
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
              </v-card-title>
              <v-card-text>
                <v-form ref="form">
                  <div v-if="state.showResetPwdForm">
                    <div class="text-h5 text-center text-primary mb-2">Reset your password</div>
                    <TextFieldPassword
                      label="Enter Password"
                      v-model="state.password"
                      color="primary"
                      class="mb-2"
                    >
                    </TextFieldPassword>
                    <TextFieldPassword
                      label="Enter confirm password"
                      v-model="state.confirmPassword"
                      color="primary"
                      class="mb-2"
                      :rules="[validatePassword() ? true : 'Password not match!']"
                    ></TextFieldPassword>
                    <div class="text-right">
                      <Button
                        :disabled="state.isDisable"
                        class="mb-3"
                        variant="elevated"
                        @click="ResetPwd"
                        >Reset password</Button
                      >
                    </div>
                  </div>
                  <div v-else>
                    <div v-if="!state.showOTPForm">
                      <div class="text-h6 text-center text-dark">Forgot your password?</div>
                      <div class="text-center text-grey mb-2">
                        Please enter your email to recieve a verification code.
                      </div>
                      <TextFieldEmail
                        label="Enter email"
                        v-model="state.email"
                        color="primary"
                        :error-messages="state.emailError ? state.emailErrorMessage : ''"
                      />
                      <div class="text-right">
                        <Button class="mb-2" @click="validateEmail()">Send OTP</Button>
                      </div>
                    </div>

                    <div v-else>
                      <div class="text-h6 text-grey mb-2">
                        OTP has been send to your email address
                      </div>
                      <TextFieldOTP
                        label="Enter OTP"
                        :error-messages="state.otpError ? state.otpErrorMessage : ''"
                        placeholder="Enter OTP e.g 435355"
                        v-model="state.otp"
                        color="primary"
                      />
                      <div class="text-right">
                        <Button @click="ValidateOTP()" :disabled="state.isDisable" class="mb-3"
                          >Submit</Button
                        >
                      </div>
                    </div>
                  </div>
                </v-form>
              </v-card-text>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </v-app>
  <SnackbarComponent v-model="state.openSnkbar" :error="state.isError">
    {{ state.resMessage }}
  </SnackbarComponent>
</template>

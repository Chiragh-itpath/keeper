<script setup lang="ts">
import { RouterEnum } from '@/enum/RouterEnum'
import { ref, reactive } from 'vue'
import TextFieldEmail from '@/components/TextFieldEmail.vue'
import TextFieldPassword from '@/components/TextFieldPassword.vue'
import type { ILogin } from '@/Models/LoginModel'
import { useAccountStore } from '@/stores/AccountStore'
import { StatusType } from '@/enum/StatusType'
import { useRouter } from 'vue-router'
import { useUserStore } from '@/stores/UserStore'
import { useTokenStore } from '@/stores/TokenStore'
import Snackbar from '@/components/SnackbarComponent.vue'
import Loader from '@/components/LoaderComponent.vue'
import { onMounted } from 'vue'
const { loginUser } = useAccountStore()
const router = useRouter()
const form = ref()
const state = reactive({
  email: '',
  password: '',
  emailError: false,
  passwordError: false,
  isSuccess: true,
  emailErrorMessage: '',
  passwordErrorMessage: '',
  showSnackbar: false,
  SnackbarMessage: '',
  isDisable: false,
  serverError: false,
  isLoading: false
})
const { StoreUser } = useUserStore()
const { setToken } = useTokenStore()
async function login(): Promise<void> {
  const { valid } = await form.value.validate()
  if (!valid) return
  state.isDisable = true
  state.isLoading = true
  const user: ILogin = {
    Email: state.email,
    Password: state.password
  }
  const [response, error] = await loginUser(user)
  if (error) {
    console.log(error)
    state.serverError = true
    state.showSnackbar = true
    state.SnackbarMessage = 'Internal Server Error'
    return
  }
  if (response.data.statusName == StatusType.NOT_FOUND) {
    state.emailError = true
    state.passwordError = false
    state.emailErrorMessage = response.data.message
  }
  if (response.data.statusName == StatusType.NOT_VALID) {
    state.passwordError = true
    state.emailError = false
    state.passwordErrorMessage = response.data.message
  }
  if (response.data.statusName == StatusType.SUCCESS) {
    state.emailError = false
    state.passwordError = false
    state.isSuccess = true
    form.value.reset()
    const { token, userId } = response.data.data
    await StoreUser(userId)
    setToken(token)
    router.push({ name: RouterEnum.PROJECT })
  }
  state.isDisable = false
  state.isLoading = false
}
</script>
<template>
  <!-- <loader v-if="state.isLoading" /> -->
  <v-app :class="{ blur: state.isLoading }">
    <v-main>
      <v-container fill-height fluid>
        <v-row justify="center" align-content="center">
          <v-col cols="12" lg="4" sm="12">
            <v-card class="elevation-12 my-auto">
              <v-card-title class="text-center mt-5">
                <h2 class="text-teal">Keeper</h2>
                Login
              </v-card-title>
              <v-card-subtitle class="text-center"> to continue to Keeper </v-card-subtitle>
              <v-card-text>
                <v-form ref="form" @submit.prevent="login">
                  <TextFieldEmail v-model="state.email" label="Email" color="primary"
                    :error-messages="state.emailError ? state.emailErrorMessage : ''" />
                  <TextFieldPassword v-model="state.password" label="Password" color="primary"
                    :error-messages="state.passwordError ? state.passwordErrorMessage : ''" />
                  <div class="text-right">
                    <router-link :to="{ name: RouterEnum.FORGOT_PASSWORD }">Forgot Password?</router-link>
                  </div>
                  <v-card-actions>
                    <div class="d-flex flex-column justify-center mx-auto">
                      <Snackbar v-model="state.showSnackbar" :error="state.serverError">
                        <v-icon v-if="state.serverError">mdi-alert</v-icon>
                        <v-icon v-else>mdi-check</v-icon>
                        {{ state.SnackbarMessage }}
                      </Snackbar>
                      <v-btn type="submit" flatcolor="#5865f2" rounded="lg" size="large" variant="flat" color="teal"
                        class="mt-4" :disabled="state.isDisable" >Login</v-btn>
                      <div class="mt-5">
                        New User?
                        <router-link :to="{ name: RouterEnum.SIGNUP }">Create an account</router-link>
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
<style scoped>
.blur {
  opacity: 0.2;
}
</style>

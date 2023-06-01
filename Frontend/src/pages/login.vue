<script setup lang="ts">
import { ref, type Ref } from 'vue';


const email: Ref<string> = ref('')
const password: Ref<string> = ref('')
const form=ref()
const requiredRule=(val:string)=>val.trim()==""?"Field is Required!":true
async function login() {
  const { valid } = await form.value.validate();
  if (valid) {
    alert("Valid")
    form.value.reset();
  }
}
</script>
<template>
    <v-container>
        <v-row align-content="center" justify="center">
            <v-col cols="12" lg="4" sm="12">
                <v-card class="elevation-12 text-center">
                    <v-card-title>
                        <h3 class="text-cyan">Keeper</h3>
                        Sign In
                    </v-card-title>
                    <v-card-subtitle>
                        to continue to Keeper
                    </v-card-subtitle>
                    <v-card-text>
                        <v-form ref="form" @submit.prevent="login()">
                            <v-text-field v-model="email" clearable name="email" label="Email" type="email"
                                placeholder="Email" variant="outlined" :rules="[requiredRule]"></v-text-field>

                            <v-text-field v-model="password" name="password" label="Password" type="password"
                                placeholder="Password" variant="outlined" :rules="[requiredRule]"></v-text-field>
                                <v-card-actions>
                                    <a href="">Create account</a>
                                    <v-spacer></v-spacer>
                                    <v-btn type="submit" class="mt-4">Login</v-btn>
                                </v-card-actions>
                        </v-form>
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>
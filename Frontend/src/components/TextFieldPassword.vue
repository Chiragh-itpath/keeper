<script setup lang="ts">
import { ref } from 'vue'
import { requiredRule, passwordRule } from '@/data/ValidationRules'

const props = withDefaults(
  defineProps<{
    label: string
  }>(),
  {
    label: ''
  }
)
const showPwd = ref(false)
</script>

<template>
  <v-text-field
    :label="props.label"
    :type="showPwd ? 'text' : 'password'"
    :rules="[requiredRule, passwordRule]"
    prepend-inner-icon="mdi-lock"
    :append-inner-icon="showPwd ? 'mdi-eye' : 'mdi-eye-off'"
    @click:append-inner="showPwd = !showPwd"
    variant="outlined"
  ></v-text-field>
</template>

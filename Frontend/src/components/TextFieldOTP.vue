<script setup lang="ts">
import { requiredRule, otpRules } from '@/data/ValidationRules'

const props = withDefaults(
  defineProps<{
    label: string
  }>(),
  {
    label: ''
  }
)
</script>

<template>
  <v-text-field
    :label="props.label"
    type="text"
    :rules="[requiredRule, otpRules]"
    clearable
    :counter="6"
    :maxlength="6"
    variant="outlined"
  ></v-text-field>
</template>

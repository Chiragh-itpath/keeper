<script setup lang="ts">
import { requiredRule, emailRules } from '@/data/ValidationRules'

const props = withDefaults(
  defineProps<{
    label: string,
    isRequired:boolean
  }>(),
  {
    label: '',
    isRequired:true
  }
)
</script>

<template>
  <v-text-field
    :label="props.label"
    type="email"
    :rules="[props.isRequired?requiredRule:true, emailRules]"
    prepend-inner-icon="mdi-email"
    clearable
    variant="outlined"
  ></v-text-field>
</template>

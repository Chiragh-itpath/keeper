<script setup lang="ts">
import { requiredRule, numberRules } from '@/data/ValidationRules'

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
    :rules="[requiredRule, numberRules]"
    clearable
    :counter="5"
    :maxlength="5"
    variant="outlined"
  ></v-text-field>
</template>

<script setup lang="ts">
import { requiredRule, emailRules } from '@/data/ValidationRules'

const props = withDefaults(defineProps<{
    label: string
}>(), {
    label: ''
})
</script>

<template>
    <v-text-field :label="props.label" type="email" :rules="[requiredRule, emailRules]" prepend-inner-icon="mdi-email"
        clearable variant="outlined" ></v-text-field>
</template>
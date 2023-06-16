<script setup lang="ts">
import {requiredRule,contactRules} from '@/data/ValidationRules'

const props=withDefaults(defineProps<{
    label:string
}>(),{
    label:''
})
</script>

<template>
    <v-text-field :label="props.label" type="text"
        :rules="[requiredRule,contactRules]"
        prepend-inner-icon="mdi-account-box"
        clearable
        :counter="10" :maxlength="10"
        variant="outlined"
    ></v-text-field>
</template>
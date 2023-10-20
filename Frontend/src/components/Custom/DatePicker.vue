<script setup lang="ts">
import { ref, watch } from 'vue'
import { VDatePicker } from 'vuetify/labs/VDatePicker'
const props = withDefaults(defineProps<{
    modelValue?: any,
    label?: string
}>(), {
    modelValue: '',
    label: ''
})
const menu = ref()
const date = ref()
const displayDate = ref(props.modelValue)

watch(date, () => {
    if (date.value) {
        const dateObj = new Date(date.value)
        displayDate.value = `${dateObj.getFullYear()}-${dateObj.getMonth() + 1}-${dateObj.getDate()}`
        emits('update:modelValue', displayDate.value)
        menu.value = false
    }
})
watch(props, () => {
    if (props.modelValue == '') {
        displayDate.value = ''
        date.value = undefined
    }
})
const emits = defineEmits<{
    (e: 'update:modelValue', modelValue: any): void
}>()

const clear = () => {
    emits('update:modelValue', '')

}
</script>
<template>
    <v-menu v-model="menu" :close-on-content-click="false" offset-y min-width="290px">
        <template v-slot:activator="{ isActive, props }">
            <v-text-field :model-value="displayDate" readonly v-bind="props" @click="isActive" :label="label"
                color="primary" clearable @click:clear="clear" />
        </template>
        <v-date-picker v-model="date" color="primary" :max="new Date()" @click:cancel="menu = false"></v-date-picker>
    </v-menu>
</template>
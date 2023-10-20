<script setup lang="ts">
import { ref, watch, type Ref } from 'vue'
import { ItemStore } from '@/stores'

const props = withDefaults(defineProps<{
    modelValue: boolean,
    id: string
}>(), {
    modelValue: false
})

const visible: Ref<boolean> = ref(false)
const { DeleteItem } = ItemStore()

const deleteHandler = async (): Promise<void> => {
    await DeleteItem(props.id)
    visible.value = false
}

watch(props, () => {
    if (props.modelValue) {
        visible.value = props.modelValue
    }
})
watch(visible, () => {
    if (!visible.value) {
        emits('update:modelValue', visible.value)
    }
})
const emits = defineEmits<{
    (e: 'update:modelValue', modelValue: boolean): void
}>()
</script>
<template>
    <v-dialog transition="scale-transition" v-model="visible" max-width="350">
        <v-card width="">
            <v-card-title class="bg-red text-center text-uppercase">
                Confirm Deletion
            </v-card-title>
            <v-card-text> are you sure want to delete this? </v-card-text>
            <v-card-actions class="py-5 d-flex justify-space-evenly">
                <v-btn variant="outlined" color="green" @click="visible = false">Cancle</v-btn>
                <v-btn variant="outlined" color="red" @click="deleteHandler">Yes</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script setup lang="ts">
import { ref, type Ref, watch } from 'vue'
import { ProjectStore } from '@/stores'

const props = withDefaults(defineProps<{
    id: string,
    modelValue: boolean
}>(), {
    id: '',
    modelValue: false
})

const visible: Ref<boolean> = ref(false)

const { DeleteProject } = ProjectStore()

const delteHandler = async (): Promise<void> => {
    visible.value = false
    await DeleteProject(props.id!)
}
watch(props, () => {
    visible.value = props.modelValue
})
watch(visible, () => {
    if (!visible.value)
        emits('update:modelValue', visible.value)
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
                <v-btn variant="outlined" color="red" @click="delteHandler">Yes</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script setup lang="ts">
import { ref, watch, type Ref, reactive } from 'vue'
import TextField from '@/components/Custom/TextField.vue'
import { KeepStore } from '@/stores'
import type { IEditKeep } from '@/Models/KeepModels'

const props = withDefaults(defineProps<{
    modelValue: boolean,
    id: string,
    projectId: string
}>(), {
    modelValue: false
})

const { Updatekeep, getSingleKeep, } = KeepStore()

const visible: Ref<boolean> = ref(false)
const form = ref()
const editKeep: IEditKeep = reactive({
    id: '',
    title: '',
    tag: '',
    projectId: ''
})

const submitHandler = async (): Promise<void> => {
    const { valid } = await form.value.validate()
    if (valid) {
        await Updatekeep(editKeep)
        visible.value = false
    }
}

watch(props, () => {
    visible.value = props.modelValue
    if (props.modelValue) {
        const keep = getSingleKeep(props.id)
        editKeep.id = keep!.id
        editKeep.title = keep!.title
        editKeep.tag = keep!.tag
        editKeep.projectId = keep!.projectId
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
    <v-dialog transition="scale-transition" v-model="visible" max-width="700" close-on-back>
        <v-card>
            <v-card-title class="text-center bg-primary"> New keep </v-card-title>
            <v-card-text>
                <v-form @submit.prevent="submitHandler" ref="form" validate-on="submit">
                    <v-row>
                        <v-col cols="12" sm="8">
                            <text-field v-model="editKeep.title" label="Title" is-required />
                        </v-col>
                        <v-col cols="12" sm="4">
                            <text-field v-model="editKeep.tag" label="Tag" />
                        </v-col>
                    </v-row>
                </v-form>
            </v-card-text>
            <v-card-actions class="justify-end ma-3">
                <v-btn @click="() => (visible = false)" color="primary" variant="outlined" min-width="100"
                    class="px-5 mx-4">
                    Close
                </v-btn>
                <v-btn @click="submitHandler" color="primary" variant="outlined" min-width="100" class="px-5 mx-2">
                    Update
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

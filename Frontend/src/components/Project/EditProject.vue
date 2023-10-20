<script lang="ts" setup>
import { reactive, ref, type Ref, watch } from 'vue'
import { ProjectStore } from '@/stores'
import TextField from '@/components/Custom/TextField.vue'
import type { IEditProject } from '@/Models/ProjectModels'

const props = withDefaults(defineProps<{
    id: string,
    modelValue: boolean
}>(), {
    id: '',
    modelValue: false
})

const { GetSingalProject, UpdateProject } = ProjectStore()

const editProject: IEditProject = reactive({
    id: '',
    title: '',
    description: '',
    tag: ''
})

const visible: Ref<boolean> = ref(props.modelValue)
const form = ref()

const submitHandler = async (): Promise<void> => {
    console.log('here')
    const { valid } = await form.value.validate()
    if (valid) {
        await UpdateProject(editProject)
        visible.value = false
    }
}
const toggle = () => {
    const project = GetSingalProject(props.id)
    editProject.id = project!.id
    editProject.title = project!.title
    editProject.description = project!.description
    editProject.tag = project!.tag

}
watch(props, () => {
    visible.value = props.modelValue
    if (props.modelValue) {
        toggle()
    }
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
    <v-dialog transition="scale-transition" v-model="visible" max-width="700">
        <v-card>
            <v-card-title class="text-center bg-primary"> Edit Project </v-card-title>
            <v-card-text>
                <v-form @submit.prevent="submitHandler" ref="form" validate-on="submit">
                    <v-row>
                        <v-col cols="12" sm="8">
                            <text-field v-model="editProject.title" label="Title" is-required />
                        </v-col>
                        <v-col cols="12" sm="4">
                            <text-field v-model="editProject.tag" label="Tag" />
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col cols="12">
                            <v-textarea v-model="editProject.description" label="Description" color="primary" />
                        </v-col>
                    </v-row>
                </v-form>
            </v-card-text>
            <v-card-actions class="justify-end ma-3">
                <v-btn @click="visible = false" color="primary" variant="outlined" min-width="100" class="px-5 mx-4">
                    Close
                </v-btn>
                <v-btn @click="submitHandler" color="primary" variant="outlined" min-width="100" class="px-5 mx-2">
                    Update
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

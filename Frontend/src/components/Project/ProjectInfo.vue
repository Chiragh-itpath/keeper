<script setup lang="ts">
import { ref, type Ref, watch } from 'vue'
import { ProjectStore, UserStore } from '@/stores'
import { dateHelper } from '@/Services/HelperFunction'
import type { IProject } from '@/Models/ProjectModels'

const props = withDefaults(defineProps<{
    id: string,
    modelValue: boolean
}>(), {
    id: '',
    modelValue: false
})

const { SingleProject } = ProjectStore()
const { User, myProfile } = UserStore()
const project: Ref<IProject | undefined> = ref()
const visible: Ref<boolean> = ref(false)

watch(props, async () => {
    visible.value = props.modelValue
    if (visible.value) {
        project.value = SingleProject(props.id)
        if (User.id == '') {
            await myProfile()
        }
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
    <v-dialog transition="scale-transition" v-model="visible" max-width="550">
        <v-card>
            <v-card-title class="text-center bg-primary">Project Details</v-card-title>
            <v-card-text>
                <v-row>
                    <v-col class="text-grey-darken-2">
                        <div><v-icon color="primary">mdi-subtitles-outline</v-icon> Title:</div>
                        <div><v-icon color="primary">mdi-account-circle-outline</v-icon> Owner:</div>
                        <div><v-icon color="primary">mdi-calendar-range</v-icon> Created On:</div>
                        <div><v-icon color="primary">mdi-file-edit-outline</v-icon> Last Modified By:</div>
                        <div><v-icon color="primary">mdi-calendar-range</v-icon> Last Modified:</div>
                    </v-col>
                    <v-col>
                        <div>{{ project?.title }}</div>
                        <div>{{ project?.createdBy == User.email ? 'me' : project?.createdBy }}</div>
                        <div>{{ dateHelper(project?.createdOn) }}</div>
                        <div>{{ project?.createdBy == User.email ? 'me' : project?.createdBy }}</div>
                        <div>{{ dateHelper(project?.updatedOn) }}</div>
                    </v-col>
                </v-row>
            </v-card-text>
            <v-card-actions class="d-flex justify-end">
                <v-btn @click="(visible = false)" class="ma-3 px-5" variant="outlined" color="primary">Close</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>
<style scoped>
.v-col>div {
    margin: 10px 0;
}
</style>
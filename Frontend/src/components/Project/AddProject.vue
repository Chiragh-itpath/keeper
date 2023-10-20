<script setup lang="ts">
import { reactive, ref, type Ref } from 'vue'
import { ProjectStore } from '@/stores'
import TextField from '@/components/Custom/TextField.vue'
import type { IAddProject } from '@/Models/ProjectModels'

const visible: Ref<boolean> = ref(false)
const form = ref()
const { AddProject } = ProjectStore()

const addProject: IAddProject = reactive({
    title: '',
    description: '',
    tag: ''
})

const submitHandler = async (): Promise<void> => {
    const { valid } = await form.value.validate()
    if (valid) {
        await AddProject(addProject)

    }
}

</script>
<template>
    <v-btn color="primary" variant="elevated" prepend-icon="mdi-plus" @click="visible = true">
        New Project
    </v-btn>
    <v-dialog transition="scale-transition" v-model="visible" max-width="700" close-on-back>
        <v-card>
            <v-card-title class="text-center bg-primary"> New Project </v-card-title>
            <v-card-text>
                <v-form @submit.prevent="submitHandler" ref="form" validate-on="submit">
                    <v-row>
                        <v-col cols="12" sm="8">
                            <text-field v-model="addProject.title" label="Title" is-required />
                        </v-col>
                        <v-col cols="12" sm="4">
                            <text-field v-model="addProject.tag" label="Tag" />
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col cols="12">
                            <v-textarea v-model="addProject.description" label="Description" color="primary"></v-textarea>
                        </v-col>
                    </v-row>
                </v-form>
            </v-card-text>
            <v-card-actions class="justify-end ma-3">
                <v-btn @click="visible = false" color="primary" variant="outlined" min-width="100" class="px-5 mx-4">
                    Close
                </v-btn>
                <v-btn @click="submitHandler" color="primary" variant="outlined" min-width="100" class="px-5 mx-2">
                    Add
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

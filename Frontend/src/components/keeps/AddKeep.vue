<script setup lang="ts">
import { reactive, ref, type Ref, watch } from 'vue'
import TextField from '@/components/Custom/TextField.vue'
import { KeepStore } from '@/stores'
import type { IAddKeep } from '@/Models/KeepModels'

const props = withDefaults(defineProps<{
    projectId: string,
}>(), {
})

const { AddKeep } = KeepStore()
const visible: Ref<boolean> = ref(false)

const form = ref()
const addKeep: IAddKeep = reactive({
    title: '',
    tag: '',
    projectId: ''
})

const submitHandler = async (): Promise<void> => {
    const { valid } = await form.value.validate()
    if (valid) {
        await AddKeep(addKeep)
        visible.value = false
    }
}
watch(visible, () => {
    if (visible.value) {
        addKeep.projectId = props.projectId
    }
})


</script>
<template>
    <v-btn class="w-100" @click="visible = true" color="primary" variant="elevated" prepend-icon="mdi-plus">
        New Keep
    </v-btn>
    <v-dialog transition="scale-transition" v-model="visible" max-width="700" close-on-back>
        <v-card>
            <v-card-title class="text-center bg-primary"> New keep </v-card-title>
            <v-card-text>
                <v-form @submit.prevent="submitHandler" ref="form" validate-on="submit">
                    <v-row>
                        <v-col cols="12" sm="8">
                            <text-field v-model="addKeep.title" label="Title" is-required />
                        </v-col>
                        <v-col cols="12" sm="4">
                            <text-field v-model="addKeep.tag" label="Tag" />
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
                    Add
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

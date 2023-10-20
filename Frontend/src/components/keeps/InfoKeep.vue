<script setup lang="ts">
import { ref, watch, type Ref } from 'vue'
import type { IKeep } from '@/Models/KeepModels'
import { dateHelper } from '@/Services/HelperFunction'
import { UserStore, KeepStore } from '@/stores'

const props = withDefaults(defineProps<{
    modelValue: boolean,
    id: string
}>(), {
    modelValue: false
})

const visible: Ref<boolean> = ref(false)
const Keep: Ref<IKeep | undefined> = ref()
const { User, myProfile } = UserStore()
const { getSingle } = KeepStore()

watch(props, async () => {
    visible.value = props.modelValue
    if (props.modelValue) {
        Keep.value = getSingle(props.id)

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
    <v-dialog transition="scale-transition" v-model="visible" max-width="400">
        <v-card>
            <v-card-title class="text-center bg-primary">Keep Details</v-card-title>
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
                        <div>{{ Keep?.title }}</div>
                        <div>{{ Keep?.createdBy == User.email ? 'me' : Keep?.createdBy }}</div>
                        <div>{{ dateHelper(Keep?.createdOn) }}</div>
                        <div>{{ Keep?.createdBy == User.email ? 'me' : Keep?.createdBy }}</div>
                        <div>{{ dateHelper(Keep?.updatedOn) }}</div>
                    </v-col>
                </v-row>
            </v-card-text>
            <v-card-actions class="justify-end">
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
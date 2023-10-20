<script setup lang="ts">
import { ref, watch, type Ref, reactive } from 'vue'
import TextField from '@/components/Custom/TextField.vue'
import TextEditor from '@/components/Custom/TextEditor.vue'
import { ItemType } from '@/Models/enum'
import { ItemStore } from '@/stores'
import type { IAddItem } from '@/Models/ItemModels'

const visible: Ref<boolean> = ref(false)
const form = ref()

const addItem: IAddItem = reactive({
    title: '',
    description: '',
    url: '',
    keepId: '',
    userId: '',
    number: 0,
    type: ItemType.TICKET,
    to: '',
    discussedBy: '',
    files: null
})
const { AddItem } = ItemStore()
const itemType = ref('Ticket')

const submitHandler = async (): Promise<void> => {
    const { valid } = await form.value.validate()
    if (!valid) return
    addItem.type = itemType.value == 'Ticket' ? ItemType.TICKET : ItemType.PR
    await AddItem(addItem)
    visible.value = false
}

const props = withDefaults(defineProps<{
    keepId: string
}>(), {
})

watch(visible, () => {
    if (visible.value) {
        addItem.keepId = props.keepId
        addItem.title = addItem.description = addItem.url = addItem.discussedBy = addItem.to = ''
        addItem.number = 0
    }
})

</script>
<template>
    <v-btn class="w-100" color="primary" variant="elevated" prepend-icon="mdi-plus" @click="visible = true">
        New Item
    </v-btn>
    <v-dialog transition="scale-transition" v-model="visible" close-on-back max-width="900">
        <v-card max-height="600" class="">
            <v-card-title class="bg-primary text-center position-sticky">New Item</v-card-title>
            <v-card-text>
                <v-form ref="form" @submit.prevent>
                    <v-row>
                        <v-col cols="6" lg="3" md="3" sm="6">
                            <v-select :items="['Ticket', 'PR']" label="Type" color="primary" v-model="itemType" />
                        </v-col>
                        <v-col cols="6" lg="3" md="3" sm="6">
                            <text-field label="Number" is-number v-model="addItem.number" />
                        </v-col>
                        <v-col>
                            <text-field label="Item Name" is-required v-model="addItem.title" />
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col cols="12">
                            <text-field label="URL" v-model="addItem.url" />
                        </v-col>
                        <v-col cols="12">
                            <text-editor v-model="addItem.description"></text-editor>
                        </v-col>
                        <v-col cols="12">
                            <v-file-input color="primary" v-model="addItem.files" />
                        </v-col>
                    </v-row>
                    <v-row>
                        <v-col cols="6">
                            <text-field label="To" v-model="addItem.to" />
                        </v-col>
                        <v-col cols="6">
                            <text-field label="Discussed by" v-model="addItem.discussedBy" />
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

<script setup lang="ts">
import { ref, watch, type Ref } from 'vue'
import { ItemStore } from '@/stores'
import type { IItem } from '@/Models/ItemModels'
import { dateHelper } from '@/Services/HelperFunction'


const { GetById } = ItemStore()

const itemtype = ['Ticket', 'PR']
const visible: Ref<boolean> = ref(false)

const Item: Ref<IItem | null> = ref(null)
const props = withDefaults(defineProps<{
    modelValue: boolean,
    id: string
}>(), {
    modelValue: false
})


watch(props, () => {
    visible.value = props.modelValue
})

watch(visible, async () => {
    Item.value = await GetById(props.id)
    if (!visible.value) {
        emits('update:modelValue', visible.value)
    }
})

const emits = defineEmits<{
    (e: 'update:modelValue', modelValue: boolean): void
}>()


</script>
<template>
    <v-dialog transition="scale-transition" v-model="visible">
        <v-row class="justify-center" v-if="Item">
            <v-col cols="12" lg="8">
                <v-card width="100%" max-height="500" class="overflow-auto">
                    <v-card-title class="bg-primary text-center">
                        <div>Item Details</div>
                    </v-card-title>
                    <v-card-text class="pt-5">
                        <v-row>
                            <v-col cols="12" lg="7" md="7" class="main">
                                <div class="mb-3 ps-3">Title: {{ Item.title }} </div>
                                <div v-if="Item.url" class="mb-3 ps-3">
                                    URL: <router-link :to="Item.url">{{ Item.url }}</router-link>
                                </div>
                                <div class="description rounded-lg ps-3 pt-3">
                                    <span v-if="Item.description">
                                        <div v-html="Item.description"></div>
                                    </span>
                                    <span v-else class="text-grey">No description provided</span>
                                </div>
                                <div class="mt-4">
                                    <div class="my-1" v-if="Item.files">Files:</div>
                                    <div v-for="(file, index) in Item.files" :key="index">
                                        <v-img v-if="file.isImage" :src="file.fileUrl"></v-img>
                                        <router-link :to="file.fileUrl" v-else>
                                            <v-chip color="primary">
                                                {{ file.fileName }}
                                            </v-chip>
                                        </router-link>
                                    </div>
                                </div>
                            </v-col>
                            <v-divider vertical thickness="2" color="black" class="d-sm-none d-md-flex"></v-divider>
                            <v-col class="ms-2 pa-sm-5 pa-md-5">
                                <div class="v-row">
                                    <span class="v-col v-col-4">type:</span>
                                    <span class="v-col v-col-8">{{ itemtype[Item.type] }} </span>
                                </div>
                                <div class="v-row">
                                    <span class="v-col v-col-4">number:</span>
                                    <span class="v-col v-col-8">{{ Item.number }}</span>
                                </div>
                                <div class="v-row">
                                    <span class="v-col v-col-4">to:</span>
                                    <span class="v-col v-col-8">{{ Item.to ?? '-' }}</span>
                                </div>
                                <div class="v-row">
                                    <span class="v-col v-col-4">discussed by:</span>
                                    <span class="v-col v-col-8">{{ Item.discussedBy ?? '-' }}</span>
                                </div>
                                <div class="v-row">
                                    <span class="v-col v-col-4">created by:</span>
                                    <span class="v-col v-col-8">{{ Item.createdBy }}</span>
                                </div>
                                <div class="v-row">
                                    <span class="v-col v-col-4">created on:</span>
                                    <span class="v-col v-col-8">{{ dateHelper(Item.createdOn) }}</span>
                                </div>
                                <div class="v-row">
                                    <span class="v-col v-col-4">updated by:</span>
                                    <span class="v-col v-col-8">{{ Item.updatedBy ?? '-' }}</span>
                                </div>
                                <div class="v-row">
                                    <span class="v-col v-col-4">updated on:</span>
                                    <span class="v-col v-col-8">{{ dateHelper(Item.updatedOn) }}</span>
                                </div>

                                <div></div>
                            </v-col>
                        </v-row>
                    </v-card-text>
                    <v-card-actions class="d-flex justify-end">
                        <v-btn class="mx-3 mb-2" width="100" variant="outlined" color="primary"
                            @click="visible = false">close</v-btn>
                    </v-card-actions>
                </v-card>
            </v-col>
        </v-row>
    </v-dialog>
</template>
<style scoped>
span.v-col {
    padding: 5px 0 !important;
}

.v-row>.v-col:first-child {
    color: #455A64;
}

.description {
    min-height: 150px;
    background-color: #ECEFF1;
    color: black;
}

.v-img {
    width: 300px;
}

.scroll-y-reverse-transition {
    transition-duration: 1s !important;
}
</style>
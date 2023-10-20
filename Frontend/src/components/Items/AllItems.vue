<script setup lang="ts">
import { ref, type Ref } from 'vue'
import { storeToRefs } from 'pinia'
import { ItemStore } from '@/stores'

import EditItem from '@/components/Items/EditItem.vue'
import DeleteItem from '@/components/Items/DeleteItem.vue'
import InfoItem from '@/components/Items/InfoItem.vue'
import HoverEffect from '@/components/Custom/HoverEffect.vue'

const { Items } = storeToRefs(ItemStore())

const id: Ref<string> = ref('')
const editVisible: Ref<boolean> = ref(false)
const deleteVisible: Ref<boolean> = ref(false)
const infoVisible: Ref<boolean> = ref(false)

</script>
<template>
    <edit-item :id="id" v-model="editVisible"></edit-item>
    <delete-item :id="id" v-model="deleteVisible"></delete-item>
    <info-item :id="id" v-model="infoVisible"></info-item>
    <v-col cols="12" sm="6" v-for="(item, index) of Items" :key="index">
        <v-card @click="() => { infoVisible = true; id = item.id }">
            <v-card-title class="bg-primary">
                <div class="d-flex">
                    <p class="text-white">{{ item.title }}</p>
                    <v-spacer></v-spacer>
                    <div>
                        <v-menu location="bottom" width="250">
                            <v-list>
                                <v-list-item role="button" class="ma-0 pa-0 mt-2"
                                    @click="() => { id = item.id; editVisible = true }">
                                    <hover-effect icon="file-document-edit-outline">
                                        Edit
                                    </hover-effect>
                                </v-list-item>
                                <v-list-item role="button" class="ma-0 pa-0 mt-2"
                                    @click="() => { id = item.id; deleteVisible = true }">
                                    <hover-effect icon="delete-outline">
                                        Delete
                                    </hover-effect>
                                </v-list-item>
                            </v-list>
                            <template v-slot:activator="{ props }">
                                <v-icon v-bind="props" color="white">mdi-dots-vertical</v-icon>
                            </template>
                        </v-menu>
                    </div>
                </div>
            </v-card-title>
            <v-card-text>
                <v-sheet height="100" class="pa-4">
                    <div v-if="item.description">
                        <div v-html="item.description"></div>
                    </div>
                    <div v-else class="text-grey">No Description</div>
                </v-sheet>
            </v-card-text>
        </v-card>
    </v-col>
</template>

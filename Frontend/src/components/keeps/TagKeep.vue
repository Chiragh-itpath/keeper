<script setup lang="ts">
import { useRouter } from 'vue-router'
import { storeToRefs } from 'pinia'
import { RouterEnum } from '@/Models/enum'
import { KeepStore } from '@/stores'

import HoverEffect from '@/components/Custom/HoverEffect.vue'
import CustomCard from '@/components/CustomCard.vue'

const router = useRouter()
const { Keeps } = storeToRefs(KeepStore())

const emits = defineEmits<{
    (e: 'invite', keepId: string, projectId: string): void,
    (e: 'edit', id: string): void,
    (e: 'delete', id: string): void
}>()



</script>
<template>
    <v-col cols="12" lg="3" md="6" sm="6" v-for="(keep, index) in Keeps" :key="index">
        <custom-card @navigate="() => router.push({ name: RouterEnum.ITEM, params: { id: keep.id } })" is-keep>
            <template #title>{{ keep.title }}</template>
            <template #menu>
                <v-menu location="bottom" width="250">
                    <v-list>
                        <v-list-item role="button" class="ma-0 pa-0" @click="emits('invite', keep.id, keep.projectId)">
                            <hover-effect icon="account-plus-outline">
                                Invite
                            </hover-effect>
                        </v-list-item>
                        <v-list-item role="button" class="ma-0 pa-0 mt-2" @click="emits('edit', keep.id)">
                            <hover-effect icon="folder-edit-outline">
                                Edit
                            </hover-effect>
                        </v-list-item>
                        <v-list-item role="button" class="ma-0 pa-0 mt-2" @click="emits('delete', keep.id)">
                            <hover-effect icon="delete-outline">
                                Delete
                            </hover-effect>
                        </v-list-item>
                    </v-list>
                    <template v-slot:activator="{ props }">
                        <v-icon v-bind="props" color="white">mdi-dots-vertical</v-icon>
                    </template>
                </v-menu>
            </template>
            <template #tagTitle v-if="keep.tag">{{ keep.tag }}</template>
        </custom-card>
    </v-col>
</template>
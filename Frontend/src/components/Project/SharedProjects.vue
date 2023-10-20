<script setup lang="ts">
import { useRouter } from 'vue-router'
import { storeToRefs } from 'pinia'
import CustomCard from '@/components/CustomCard.vue'
import HoverEffect from '@/components/Custom/HoverEffect.vue'
import { ProjectStore } from '@/stores'
import { RouterEnum } from '@/Models/enum'

const { Projects } = storeToRefs(ProjectStore())
const router = useRouter()
const emits = defineEmits<{
    (e: 'invite', id: string): void,
    (e: 'edit', id: string): void,
    (e: 'delete', id: string): void,
    (e: 'info', id: string): void
}>()

</script>
<template>
    <v-col cols="12" lg="3" md="6" sm="6" v-for="(project, index) in Projects" :key="index">
        <custom-card :share-icon="project.isShared"
            @navigate="() => router.push({ name: RouterEnum.KEEP, params: { id: project.id } })">
            <template #title>{{ project.title }}</template>
            <template #menu>
                <v-menu location="bottom" width="250">
                    <v-list>
                        <v-list-item role="button" class="ma-0 pa-0" @click="emits('info', project.id)">
                            <hover-effect icon="information-outline">
                                Info
                            </hover-effect>
                        </v-list-item>
                        <v-list-item role="button" class="ma-0 pa-0" @click="emits('edit', project.id)">
                            <hover-effect icon="folder-edit-outline">
                                Edit
                            </hover-effect>
                        </v-list-item>
                        <v-list-item role="button" class="ma-0 pa-0 " @click="emits('delete', project.id)">
                            <hover-effect icon="delete-outline">
                                Delete
                            </hover-effect>
                        </v-list-item>
                    </v-list>
                    <template v-slot:activator="{ props }">
                        <v-icon v-bind="props" color="grey-lighten-4">mdi-dots-vertical</v-icon>
                    </template>
                </v-menu>
            </template>
            <template #description v-if="project.description">
                {{ project.description }}
            </template>
            <template #tagTitle v-if="project.tag">{{ project.tag }}</template>
        </custom-card>
    </v-col>
</template>
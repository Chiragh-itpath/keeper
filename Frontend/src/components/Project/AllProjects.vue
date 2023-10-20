<script setup lang="ts">
import { ref, type Ref } from 'vue'
import { storeToRefs } from 'pinia'
import { ProjectStore } from '@/stores'
import { RouterEnum } from '@/Models/enum'
import { useRouter } from 'vue-router'
import EditProject from '@/components/Project/EditProject.vue'
import DeleteProject from '@/components/Project/DeleteProject.vue'
import InviteProject from '@/components/Project/InviteProject.vue'
import InfoProject from '@/components/Project/ProjectInfo.vue'
import HoverEffect from '@/components/Custom/HoverEffect.vue'
import CustomCard from '@/components/CustomCard.vue'


const { Projects } = storeToRefs(ProjectStore())
const router = useRouter()
const id: Ref<string> = ref('')
const editVisible: Ref<boolean> = ref(false)
const deleteVisible: Ref<boolean> = ref(false)
const infoVisible: Ref<boolean> = ref(false)
const inviteVisible: Ref<boolean> = ref(false)


</script>
<template>
    <edit-project :id="id" v-model="editVisible"></edit-project>
    <delete-project :id="id" v-model="deleteVisible"></delete-project>
    <info-project :id="id" v-model="infoVisible"></info-project>
    <invite-project :id="id" v-model="inviteVisible"></invite-project>

    <v-col cols="12" lg="3" md="4" sm="6" v-for="(project, index) in Projects" :key="index">
        <custom-card :share-icon="project.isShared"
            @navigate="() => router.push({ name: RouterEnum.KEEP, params: { id: project.id } })">
            <template #title>{{ project.title }}</template>
            <template #menu>
                <v-menu location="bottom" width="250">
                    <v-list>
                        <v-list-item role="button" class="ma-0 pa-0" @click="() => { infoVisible = true; id = project.id }">
                            <hover-effect icon="information-outline">
                                Info
                            </hover-effect>
                        </v-list-item>
                        <v-list-item role="button" class="ma-0 pa-0"
                            @click="() => { inviteVisible = true; id = project.id }">
                            <hover-effect icon="account-plus-outline">
                                Invite
                            </hover-effect>
                        </v-list-item>
                        <v-list-item role="button" class="ma-0 pa-0" @click="() => { editVisible = true; id = project.id }">
                            <hover-effect icon="folder-edit-outline">
                                Edit
                            </hover-effect>
                        </v-list-item>
                        <v-list-item role="button" class="ma-0 pa-0"
                            @click="() => { deleteVisible = true; id = project.id }">
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
<style scoped>
.v-chip {
    cursor: pointer;
}
</style>
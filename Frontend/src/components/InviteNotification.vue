<script setup lang="ts">
import { onMounted } from 'vue'
import { storeToRefs } from 'pinia'
import { Uitlity, InviteStore } from '@/stores'

const { NotificationCount } = storeToRefs(Uitlity())
const { InvitedProjectList, InvitedKeepList } = storeToRefs(InviteStore())
const { ProjectInviteResponse, keepInviteResponse, FetchInvitedProjects, FetchInvitedKeeps } = InviteStore()

const onProjectInviteAccept = async (id: string): Promise<void> => {
    await ProjectInviteResponse(id, true)
    InvitedProjectList.value = InvitedProjectList.value.filter(x => x.projectId != id)
}
const onProjectInviteDecline = async (id: string): Promise<void> => {
    await ProjectInviteResponse(id, false)
    InvitedProjectList.value = InvitedProjectList.value.filter(x => x.projectId != id)
}
const onKeepInviteAccept = async (id: string): Promise<void> => {
    await keepInviteResponse(id, true)
    InvitedKeepList.value = InvitedKeepList.value.filter(x => x.keepId != id)
}
const onKeepInviteDecline = async (id: string): Promise<void> => {
    await keepInviteResponse(id, false)
    InvitedKeepList.value = InvitedKeepList.value.filter(x => x.keepId != id)
}
onMounted(async (): Promise<void> => {
    await FetchInvitedProjects()
    await FetchInvitedKeeps()
})
</script>
<template>
    <v-menu location="bottom" transition="scale-transition">
        <template v-slot:activator="{ props }">
            <span class="me-10">
                <v-badge :content="NotificationCount" color="red" v-if="NotificationCount > 0">
                    <v-icon size="30" color="primary" v-bind="props">mdi-bell</v-icon>
                </v-badge>
                <v-icon size="30" color="primary" v-bind="props" v-else>mdi-bell</v-icon>
            </span>
        </template>
        <v-card max-width="450">
            <v-card-text class="ma-0 pa-0 px-3">
                <v-card v-for="(notification, index) in InvitedProjectList" :key="index" class="my-3 custom-card rounded-lg"
                    elevation="0">
                    <v-card-text class="ma-0 pa-0 px-3 pt-2">
                        <div>
                            <span class="font-weight-bold">
                                {{ notification.email }}
                            </span>
                            has invited you to project
                            <span class="font-weight-bold">
                                '{{ notification.name }}'
                            </span>
                        </div>
                    </v-card-text>
                    <v-card-actions class="d-flex justify-end ma-0 pa-0 px-3 ">
                        <v-icon color="green" role="button" size="x-large" class="mx-4"
                            @click="onProjectInviteAccept(notification.projectId)">
                            mdi-check-circle-outline
                        </v-icon>
                        <v-icon color="red" role="button" size="x-large"
                            @click="onProjectInviteDecline(notification.projectId)">
                            mdi-close-circle-outline
                        </v-icon>
                    </v-card-actions>
                </v-card>
                <v-card v-for="(notification, index) in InvitedKeepList" :key="index" class="my-3 custom-card rounded-lg"
                    elevation="0">
                    <v-card-text class="ma-0 pa-0 px-3 pt-2">
                        <div>
                            <span class="font-weight-bold">
                                {{ notification.email }}
                            </span>
                            has invited you to keep
                            <span class="font-weight-bold">
                                '{{ notification.name }}'
                            </span>
                        </div>
                    </v-card-text>
                    <v-card-actions class="d-flex justify-end ma-0 pa-0 px-3 ">
                        <v-icon color="green" role="button" size="x-large" class="mx-4"
                            @click="onKeepInviteAccept(notification.keepId)">
                            mdi-check-circle-outline
                        </v-icon>
                        <v-icon color="red" role="button" size="x-large" @click="onKeepInviteDecline(notification.keepId)">
                            mdi-close-circle-outline
                        </v-icon>
                    </v-card-actions>
                </v-card>

                <v-card v-if="InvitedProjectList.length == 0 && InvitedKeepList.length == 0" class="text-center text-grey"
                    min-width="300" elevation="0">
                    <v-card-text>
                        No new invitation
                    </v-card-text>
                </v-card>
            </v-card-text>
        </v-card>
    </v-menu>
</template>
<style scoped>
.custom-card {
    border-left: 5px solid #26A69A;
    background: #ECEFF1;
}

.v-icon--size-x-large {
    font-size: calc(var(--v-icon-size-multiplier) * 2rem);
}
</style>
<script setup lang="ts">
import { UserStore, Uitlity } from '@/stores'
import InviteNotification from '@/components/InviteNotification.vue'
import { RouterEnum } from '@/Models/enum'
import { onMounted } from 'vue';
let { logout, User, myProfile } = UserStore()
const { ToggleSideBar } = Uitlity()

const toggleSidebar = (): void => {
    ToggleSideBar()
}
onMounted(async () => {
    await myProfile()
})
</script>
<template>
    <v-app-bar>
        <v-hover v-slot="{ isHovering, props }">
            <div role="button" class="mx-5 rounded-circle" :class="isHovering ? 'bg-blue-grey-lighten-4' : ''"
                v-bind="props" @click="toggleSidebar">
                <v-icon color="primary" class="ma-2">mdi-menu</v-icon>
            </div>
        </v-hover>
        <router-link :to="{ name: RouterEnum.PROJECT }" class="text-primary text-h5 ms-0">Keeper</router-link>
        <v-spacer></v-spacer>
        <div class="d-flex align-center me-10">
            <invite-notification />

            <v-menu :close-on-content-click="false" transition="scale-transition" location="bottom">
                <template v-slot:activator="{ props }">
                    <v-avatar color="primary" v-bind="props" role="button">{{ User.email[0]?.toUpperCase() }}</v-avatar>
                </template>
                <v-card width="400" class="bg-grey-lighten-5">
                    <v-card-title class="">
                        <div class="text-center">
                            <div class="my-3">
                                <v-avatar color="primary">{{ User.email[0]?.toUpperCase() }}</v-avatar>
                            </div>
                            <div>Hi, {{ User.userName }}</div>
                            <div class="text-grey my-3"> {{ User.email }}</div>
                        </div>
                    </v-card-title>
                    <v-card-actions class="justify-center mb-3">
                        <v-btn variant="outlined" color="primary" @click="logout" width="150" height="40"
                            append-icon="mdi-logout"> Logout </v-btn>
                    </v-card-actions>
                </v-card>
            </v-menu>
        </div>
    </v-app-bar>
</template>
<style>
.pointer {
    cursor: pointer;
}
</style>

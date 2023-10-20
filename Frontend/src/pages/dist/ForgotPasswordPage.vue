<script setup lang="ts">

</script>
<template>
    <div class="bg"></div>

    <v-container fill-height fluid>
        <v-row justify="center" align-content="center" class="h-screen">
            <v-col cols="12" lg="4" sm="12">
                <v-card elevation="10" class="rounded-xl">
                    <v-card-title class="text-center mt-5">
                        <h2 class="text-teal">Keeper</h2>
                    </v-card-title>
                    <v-card-text>
                        <div class="text-center text-h6 mb-6">Reset Your Password</div>
                        <router-view></router-view>
                    </v-card-text>
                </v-card>
            </v-col>
        </v-row>
    </v-container>
</template>
<style>
.h-screen {
    height: calc(100vh - 10px) !important;
}
</style>
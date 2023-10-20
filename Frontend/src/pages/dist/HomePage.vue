<script setup lang="ts">
import homeimg from '@/assests/images/Home.jpg'
import { RouterEnum } from '@/Models/enum'
</script>
<template>
    <v-row class="flex-wrap-reverse align-center h-screen ma-0">
        <v-col cols="12" md="6">
            <v-sheet class="text-center">
                <v-row class="mt-md-6 mt-lg-10">
                    <v-col cols="12" class="text-md-h2 text-sm-h3 text-h4">
                        <span class="text-primary">Create.</span>
                        <span class="">Organize.</span>
                    </v-col>
                </v-row>
                <v-row class="mt-3 mt-md-6 mt-lg-10">
                    <v-col cols="12" class="text-md-h2 text-sm-h3 text-h4">
                        <span>Share.</span>
                        <span class="text-primary">Easy.</span>
                    </v-col>
                </v-row>
                <v-row class="mt-3 mt-md-6 mt-lg-10 text-md-h6 text-body-2 justify-center text-left">
                    <v-col cols="12" lg="8">
                        <p>
                            Keeper is the best place to note down quick thoughts or to save longer
                            notes filled with checklist, images ,web links, docs.
                        </p>
                    </v-col>
                </v-row>
                <div class="d-flex mt-5 justify-center">
                    <router-link :to="{ name: RouterEnum.LOGIN }">
                        <v-btn variant="outlined" color="primary" class="mx-4 rounded-xl" width="110" height="40">
                            Login
                        </v-btn>
                    </router-link>
                    <router-link :to="{ name: RouterEnum.SIGNUP }">
                        <v-btn variant="elevated" color="primary" class="mx-4 rounded-xl" width="110"
                            height="40">Signup</v-btn>
                    </router-link>
                </div>
            </v-sheet>
        </v-col>
        <v-col cols="12" md="6">
            <v-img :src="homeimg" width="100%" cover :aspect-ratio="1"></v-img>
        </v-col>
    </v-row>
</template>

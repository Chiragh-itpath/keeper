<script setup lang="ts">
import img from '@/assests/images/Home.jpg'
import MyBtn from '@/components/MyBtn.vue';
</script>

<template>
 <v-toolbar color="white" density="comfortable" title="Keeper" class="pa-2"><v-btn color="teal-lighten-2" class="ma-5 mx-3 font-weight-bold" variant="outlined" rounded>Login</v-btn><v-btn color="light-green"  variant="outlined" class="ma-5 mx-3 font-weight-bold" rounded>Register</v-btn></v-toolbar>
 <v-container fluid class="p-0">
    <v-row >
        <v-col cols="12" lg="6" sm="12">
            <h2 class="heading"><span class="text-teal-lighten-2">Create.</span>Organize.<br/>Share.<span class="text-light-green">Easy.</span></h2>
            <p class="description">Keeper is the best place to jot down quick thougts or to save longer notes filled with Checklists,Images,Web Links and Docs.</p>
            <my-btn title="Get Started"></my-btn>
            <my-btn title="Get Started"></my-btn>
            <!-- <v-btn color="light-green" class="ms-9 ma-5 mt-5" size="large" rounded>Get Started</v-btn> -->
        </v-col>
        <v-col cols="12" lg="6" sm="12">
            <v-img :src="img" class="w-100" cover></v-img>
        </v-col>
    </v-row>
 </v-container>
</template>

<style scoped>
h2.heading{
    font-size: 90px;
    font-weight: 600;
    margin-top: 200px;
    margin-left: 50px;
   
}
p.description{
    font-size:20px;
    font-weight: 200;
    width:600px;
    margin-left: 50px;
    font-family:'Times New Roman', Times, serif
}
</style>
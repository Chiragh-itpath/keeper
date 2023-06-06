<script setup lang="ts">
import img from '@/assests/images/Home.jpg'
import MyBtn from '@/components/MyBtn.vue';
import CardComponent from '@/components/CardComponent.vue';
</script>

<template>
    <h1></h1>
    <v-container fluid>
        <v-row>
            <v-col cols="12" md="6">
                <v-sheet class="text-center">                                    
                            <div class="text-h3 text-center">
                                <v-row>
                                    <v-col class="ml-10">
                                        <span class="text-teal-lighten-2">Create.</span>
                                    </v-col>
                                    <v-col class="mr-10">
                                        Organize.
                                    </v-col>
                                </v-row>
                                <v-row>
                                    <v-col>
                                        Share.
                                    </v-col>
                                    <v-col>
                                        <span
                                    class="text-light-green">Easy.</span>
                                    </v-col>
                                </v-row>
                            </div>                  
                </v-sheet>
            </v-col>
            <v-col>
                <v-img :src="img" height="750" cover />
            </v-col>
        </v-row>
    </v-container>
    <!-- <v-container fluid>
        <v-toolbar color="white" density="comfortable" title="Keeper" class="pa-2"><v-btn color="teal-lighten-2"
                class="ma-5 mx-3 font-weight-bold" variant="outlined" rounded>Get Started</v-btn><v-btn color="light-green"
                variant="outlined" class="ma-5 mx-3 font-weight-bold" rounded>Get Started</v-btn></v-toolbar>
        <v-row>
            <v-col lg="6" sm="12" md="12">
                <card-component>
                    <template #title>
                        <div class="text-h2">
                            <span class="text-teal-lighten-2">Create.</span>Organize.<br />Share.<span
                                class="text-light-green">Easy.</span>
                        </div>
                    </template>

                </card-component>

            </v-col>
            <v-col lg="6" sm="12" md="12">
                <card-component>
                    <template #image>                   
                            <v-img :src="img" class="" cover/>
                
                    </template>
                </card-component>
            </v-col>

        </v-row> 

    </v-container>-->
</template>

<script setup lang="ts">
import { RouterEnum } from "@/enum/RouterEnum";
import Button from '@/components/ButtonComponent.vue';
import Card from '@/components/CardComponent.vue';
</script>
<template>
    <v-container>       
        <v-row>
            <v-col cols="12" md="10" sm="12">
                <v-text-field color="primary" type="date"></v-text-field>
            </v-col>
            <v-col cols="12" md="2" sm="12" class="my-auto">
                <Button class="w-100" :rounded="false" variant="elevated" prepend-icon="mdi-plus">
                    New Keep
                </Button>
            </v-col>
        </v-row>
        <v-row >
            <v-col v-for="item in 50" :key="item" cols="12" lg="3" md="12" sm="6">
                <Card>             
                    <template #title>
                        Keep {{ item }}
                    </template>
                    <template #actions>
                        <Button variant="outlined"><router-link :to="{name:RouterEnum.ITEM}" class="link">Click</router-link></Button>
                    </template>
                </Card>
            </v-col>
        </v-row>
    </v-container>
</template>

<style scoped>
.link{
    text-decoration: none;
    color: black;
}</style>
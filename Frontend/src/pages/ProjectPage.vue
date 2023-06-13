<script setup lang="ts">
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
                    new folder
                </Button>
            </v-col>
        </v-row>
        <v-row>
            <v-col v-for="item in 100" :key="item" cols="12" lg="3" md="4" sm="6">
                <router-link to="/Projects" class="text-decoration-none">
                    <Card>
                        <template #title>
                            project {{ item }}
                        </template>
                    </Card>
                </router-link>
            </v-col>
        </v-row>
    </v-container>
</template>

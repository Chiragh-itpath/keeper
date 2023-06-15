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
            <v-col cols="12" md="2" sm="12" class="my-4">
                <Button variant="elevated" size="small" class="my-auto">
                    <v-icon size="large">mdi-plus</v-icon>
                </Button>
            </v-col>
        </v-row>
        <v-row >
            <v-col v-for="item in 100" :key="item" cols="12" lg="3" md="4" sm="6">
                <Card>
                    <template #title>
                        Keep {{ item }}
                    </template>
                </Card>
            </v-col>
        </v-row>
    </v-container>
</template>
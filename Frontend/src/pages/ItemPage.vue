<script setup lang="ts">
import Button  from "@/components/ButtonComponent.vue";
import Card from "@/components/CardComponent.vue";
</script>
<template>
    <v-container>
        <v-row>
            <v-col cols="12" md="10" sm="12">
                <v-text-field type="date" color="primary"></v-text-field>
            </v-col>
            <v-col cols="12" md="2" sm="12">
                <Button variant="elevated" class="my-3" prepend-icon="mdi-plus">Add New Item</Button>
            </v-col>
        </v-row>
        <v-row>
            <v-col>
                <Card>
                    <template #title>
                        <v-chip color=""></v-chip>
                    </template>
                </Card>
            </v-col>
        </v-row>
    </v-container>
</template>
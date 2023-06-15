<script setup lang="ts">
import Button from "@/components/ButtonComponent.vue";
import Card from "@/components/CardComponent.vue";
var items: { title: string }[] = [
    {
        title: 'Edit'
    },
    {
        title: 'Delete'
    }
]
</script>
<template>
    <v-container>
        <v-row>
            <v-col cols="12" lg="10" md="9" sm="12">
                <v-text-field type="date" color="primary"></v-text-field>
            </v-col>
            <v-col cols="12" lg="2" md="3" sm="12">
                <Button class="w-100 mt-3" :rounded="false" variant="elevated" prepend-icon="mdi-plus">Add New Item</Button>
            </v-col>
        </v-row>
        <v-row>
            <v-col cols="12" md="12">
                <Card v-for="item in 10" :key="item" class="mb-10">
                    <template #title>
                        <v-row>
                            <v-col cols="4" md="2">
                                <v-chip color="secondary">#{{ item }}</v-chip>
                            </v-col>
                            <v-col cols="5" md="7">
                                <p class="text-center">
                                    Item {{ item }}
                                </p>
                            </v-col>
                            <v-col cols="3">
                                <div class="d-flex justify-space-between float-end">
                                    <v-checkbox color="primary"></v-checkbox>
                                    <v-menu>
                                        <template v-slot:activator="{ props }">
                                            <Button variant="text" color="" v-bind="props">
                                                <v-icon color="primary">mdi-dots-vertical</v-icon>
                                            </Button>
                                        </template>
                                        <v-list>
                                            <v-list-item v-for="(item, index) in items" :key="index" :value="index">
                                                <v-list-item-title>{{ item.title }}</v-list-item-title>
                                            </v-list-item>
                                        </v-list>
                                    </v-menu>
                                </div>
                            </v-col>
                        </v-row>
                    </template>
                    <template #text>
                        description{{ item }}
                    </template>
                </Card>
            </v-col>
        </v-row>
    </v-container>
</template>
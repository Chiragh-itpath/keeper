<script setup lang="ts">
</script>
<template>
    <v-row>
        <v-col cols="12" class="d-flex justify-center align-center mt-10">
            <v-card elevation="0" height="400" class="d-flex justify-center align-center flex-column">
                <div class="bg-blue-grey-lighten-5 rounded-circle pa-10">
                    <v-icon color="primary" size="150">mdi-notebook-remove</v-icon>
                </div>
                <p class="text-h5 mt-10 text-primary">
                    <slot></slot>
                </p>
                <p class="text-grey-darken-1 mt-2">
                    Please click add button to insert new record
                </p>
            </v-card>
        </v-col>
    </v-row>
</template>

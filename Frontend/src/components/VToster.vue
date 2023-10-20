<script lang="ts" setup>
import { storeToRefs } from 'pinia'
import { Uitlity } from '@/stores'
import { Colors } from '@/Models/enum'

const { text, visible, color } = storeToRefs(Uitlity())

</script>
<template>
    <v-snackbar v-model="visible" :color="color" location="end top" @click="visible = false" role="button">
        <div class="d-flex align-center">
            <div class="mx-3">
                <v-icon v-if="color == Colors.SUCCESS" size="x-large">mdi-check</v-icon>
                <v-icon v-if="color == Colors.WARNING" size="x-large">mdi-alert</v-icon>
                <v-icon v-if="color == Colors.DANGER" size="x-large">mdi-alert-circle-outline</v-icon>
            </div>
            <div class="d-flex flex-column">
                <div class="text-body">
                    <span v-if="color == Colors.SUCCESS">Success!</span>
                    <span v-if="color == Colors.WARNING">Warning!</span>
                    <span v-if="color == Colors.DANGER">Error!</span>
                </div>
                <span>
                    {{ text }}
                </span>
            </div>
        </div>
    </v-snackbar>
</template>
@/stores

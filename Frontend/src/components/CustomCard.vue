<script setup lang="ts">
import { useSlots } from 'vue'
withDefaults(defineProps<{
    shareIcon?: boolean,
    isKeep?: boolean
}>(), {
    shareIcon: false,
    isKeep: false
})
const emits = defineEmits<{
    navigate: []
}>()
const slots = useSlots()
</script>
<template>
    <v-card elevation="7">
        <v-card-title class="bg-primary">
            <div class="d-flex">
                <p class="text-white">
                    <slot name="title"></slot>
                </p>
                <v-spacer></v-spacer>
                <div>
                    <slot name="menu"></slot>
                </div>
            </div>
        </v-card-title>
        <v-card-text @click="emits('navigate')" role="button" v-if="!isKeep">
            <v-sheet height="100" class="pa-4 px-1">
                <div v-if="!!slots['description']">
                    <slot name="description"></slot>
                </div>
                <div v-else class="text-grey">No Description</div>
            </v-sheet>
        </v-card-text>
        <v-card-actions class="justify-space-between">
            <div>
                <v-chip v-if="!!slots['tagTitle']" variant="elevated" color="primary">
                    <div>
                        #<slot name="tagTitle"></slot>
                    </div>
                </v-chip>
            </div>
            <div>
                <v-icon size="x-large" role="button" color="primary" v-if="shareIcon">
                    mdi-account-box-multiple-outline
                </v-icon>
            </div>
        </v-card-actions>
    </v-card>
</template>
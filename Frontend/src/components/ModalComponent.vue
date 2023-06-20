<script setup lang="ts">
const props = withDefaults(defineProps<{
    dialog: boolean
    width: number
}>(), {
    dialog: false,
    width: 800
},)
</script>

<template>
    <v-row justify="center">
        <v-dialog v-model="props.dialog" persistent width="800">
            <v-card>
                <v-card-title>
                    <slot name="title"></slot>
                </v-card-title>
                <v-card-text>
                    <slot name="formSlot"></slot>
                </v-card-text>
                <v-card-actions class="align-self-center">
                    <slot name="actionBtn"></slot>
                </v-card-actions>
            </v-card>
        </v-dialog>

    </v-row>
</template>

  
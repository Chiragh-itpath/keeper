<script setup lang="ts">
import { ref } from 'vue';
const dialog = ref(false);
const form = ref()
const props = withDefaults(defineProps<{
    dialog: boolean
    width: number
}>(),{
    dialog:false,
    width:800
})

</script>

<template>
    <v-row justify="center">
        <v-dialog v-model="props.dialog" persistent :width="props.width">
            
            <v-card>
                <v-card-title>
                        <slot name="title"></slot>
                    </v-card-title>
                    <v-card-text>
                        <slot name="formSlot"></slot>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <slot name="actionBtn"></slot>
                    </v-card-actions>
                </v-card>
        </v-dialog>
        
    </v-row>
</template>

  
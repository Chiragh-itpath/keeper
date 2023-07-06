<script setup lang="ts">
import ButtonComponent from './ButtonComponent.vue';
const props = withDefaults(
  defineProps<{
    dialog: boolean
  }>(),
  {
    dialog: false,
  }
)


</script>
<template>
    <v-row justify="center">
    <v-dialog v-model="props.dialog" persistent :width="400">
      <v-card>
        <v-card-title class="text-h6 text-red">
        <v-icon icon="mdi-information-outline"></v-icon>
           Confirm Deletion
        </v-card-title>
        <v-card-text>
            Are you sure want to delete?
        </v-card-text>
        <v-card-actions>
            <v-spacer></v-spacer>
            <ButtonComponent @click="$emit('deleteAction', false)">Cancle</ButtonComponent>
            <ButtonComponent variant="flat" color="red"  @click="$emit('deleteAction', true)">Delete</ButtonComponent>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>
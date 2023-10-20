<script setup lang="ts">
import { storeToRefs } from 'pinia'
import { Uitlity } from '@/stores'

const { Loading } = storeToRefs(Uitlity())
</script>

<template>
    <div class="text-center" v-if="Loading">
        <v-overlay class="align-center justify-center" :model-value="true" :persistent="true">
            <v-progress-circular color="primary" indeterminate size="x-large"></v-progress-circular>
        </v-overlay>
    </div>
</template>

<style scoped>
.v-progress-circular {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    z-index: 999;
}
</style>

<script setup lang="ts">
import { computed, ref, watch, type Ref } from 'vue'
import { storeToRefs } from 'pinia'
import { useRoute, useRouter } from 'vue-router'
import { KeepStore } from '@/stores'

import AddKeep from '@/components/keeps/AddKeep.vue'
import NoItem from '@/components/NoItem.vue'
import DatePicker from '@/components/Custom/DatePicker.vue'

const router = useRouter()
const { FilterByDate } = KeepStore()
const { Keeps } = storeToRefs(KeepStore())

const addVisible: Ref<boolean> = ref(false)
const date = ref()

watch(date, () => {
    FilterByDate(date.value)
})

const route = useRoute()

const projectId = computed(() => {
    const id = route.params.id
    return Array.isArray(id) ? id.join('') : id
})
</script>
<template>
    <v-container>
        <v-row>
            <v-col cols="12">
                <v-btn color="primary" prepend-icon="mdi-arrow-left" @click="router.go(-1)">Back</v-btn>
            </v-col>
            <v-col>
                <date-picker label="Select a Date" v-model="date"></date-picker>
            </v-col>
            <v-col cols="12" lg="2" md="3" sm="6" class="my-auto d-flex justify-end">
                <add-keep :project-id="projectId" v-model="addVisible"></add-keep>
            </v-col>
        </v-row>
        <v-row>
            <v-col cols="12" v-if="date">
                Filter By:
                <v-chip color="black" closable v-if="date" @click:close="date = ''" class="mx-3 pa-3">Date</v-chip>
            </v-col>
            <no-item v-if="Keeps.length == 0">
                No record has been added yet
            </no-item>

            <router-view></router-view>
        </v-row>
    </v-container>
</template>

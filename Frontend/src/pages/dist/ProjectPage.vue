<script setup lang="ts">
import { ref, watch } from 'vue'
import { storeToRefs } from 'pinia'
import AddProject from '@/components/Project/AddProject.vue'
import DatePicker from '@/components/Custom/DatePicker.vue'
import NoItem from '@/components/NoItem.vue'
import { ProjectStore } from '@/stores'

const { FilterByDate, FetchProjects } = ProjectStore()
const { Projects } = storeToRefs(ProjectStore())
const date = ref('')


watch(date, (val) => {
    if (date.value == '') {
        FetchProjects()
    } else {
        FilterByDate(val)
    }
})

</script>
<template>
    <v-container>

        <v-row>
            <v-col>
                <date-picker label="Select a Date" v-model="date"></date-picker>
            </v-col>
            <v-col cols="12" lg="2" md="3" sm="6" class="my-auto d-flex justify-end">
                <add-project />
            </v-col>
        </v-row>
        <v-row>
            <v-col cols="12" v-if="date != ''">
                Filter By:
                <v-chip color="black" closable @click:close="date = ''" class="mx-3 pa-3">Date</v-chip>
            </v-col>
            <no-item v-if="Projects.length == 0">
                No record has been added yet
            </no-item>
            <router-view></router-view>
        </v-row>

    </v-container>
</template>

<style scoped>
.v-list-item {
    min-height: 0 !important;
    margin: 5px 0 !important;
}
</style>

<script setup lang="ts">
import { computed, ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import AddItem from '@/components/Items/AddItem.vue'
import AllItems from '@/components/Items/AllItems.vue'
import NoItem from '@/components/NoItem.vue'
import DatePicker from '@/components/Custom/DatePicker.vue'
import { ItemStore } from '@/stores'
import { storeToRefs } from 'pinia'


const router = useRouter()
const route = useRoute()
const { Items } = storeToRefs(ItemStore())
const { FilterByDate } = ItemStore()

const date = ref()


const keepId = computed(() => {
    const id = route.params.id
    return Array.isArray(id) ? id.join('') : id
})

watch(date, () => {
    FilterByDate(date.value)
})
</script>
<template>
    <v-container>
        <v-row>
            <v-col cols="12">
                <v-btn color="primary" prepend-icon="mdi-arrow-left" @click="router.go(-1)">Back</v-btn>
            </v-col>
            <v-col>
                <date-picker label="Select a date" v-model="date"></date-picker>
            </v-col>
            <v-col cols="12" lg="2" md="3" sm="6" class="my-auto d-flex justify-end">
                <add-item :keep-id="keepId"></add-item>


            </v-col>
        </v-row>
        <v-col cols="12" v-if="date">
            Filter By:
            <v-chip color="black" closable v-if="date" @click:close="date = ''" class="mx-3 pa-3">Date</v-chip>
        </v-col>
        <v-row>
            <all-items></all-items>
        </v-row>
        <no-item v-if="Items.length == 0">
            No record has been added yet
        </no-item>


    </v-container>
</template>

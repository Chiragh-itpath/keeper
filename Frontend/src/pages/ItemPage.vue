<script setup lang="ts">
import Button from '@/components/ButtonComponent.vue'
import Card from '@/components/CardComponent.vue'
import ModalComponent from '@/components/ModalComponent.vue'
import TextFieldText from '@/components/TextFieldText.vue'
import TextFieldNumber from '@/components/TextFieldNumber.vue'
import { reactive, ref } from 'vue'
import type { IItem } from '@/Models/ItemModel'
import { ItemType } from '@/enum/ItemType'
import { useRoute } from 'vue-router'
import { useItemStore } from '@/stores/ItemStore'
import { onMounted } from 'vue'
import { storeToRefs } from 'pinia'
import { watch } from 'vue'
import Navbar from '@/components/NavBar.vue'
import RecordNotFoundComponent from '@/components/RecordNotFoundComponent.vue'
import DeleteComponent from '@/components/DeleteComponent.vue'
const { AddItem, GetItem, GetAllItems, DeleteItem, UpdateItem } = useItemStore()
const { Items } = storeToRefs(useItemStore())
let filtereditems = ref(Items.value)
watch(Items, async () => {
  filtereditems.value = Items.value
})
var list: { name: string }[] = [
  {
    name: 'Ticket'
  },
  {
    name: 'PR'
  }
]
const route = useRoute()

const state = reactive({
  itemId: '',
  dialog: false,
  title: '',
  itemUrl: '',
  openSnackbar: false,
  description: '',
  number: '',
  ItemType: 'Ticket',
  isDeleted:false
})
let attachment = ref()
async function addItem(): Promise<void> {
  if (state.itemId == '') {
    const { valid } = await form.value.validate()
    if (!valid) return
    const Items: IItem = {
      title: state.title,
      description: state.description,
      number: state.number,
      url: state.itemUrl,
      type: state.ItemType == 'Ticket' ? ItemType.TICKET : ItemType.PR,
      keepId: route.params.id.toString(),
      files: attachment.value
    }
    form.value.reset()
    await AddItem(Items)
    state.dialog = false
  } else {
    const Item: IItem = {
      id: state.itemId,
      title: state.title,
      description: state.description,
      number: state.number,
      type: state.ItemType == 'Ticket' ? ItemType.TICKET : ItemType.PR,
      url: state.itemUrl,
      files: attachment.value
    }
    await editItem(state.itemId)
    await UpdateItem(Item)
    state.itemId = ''
    form.value.reset()
    state.dialog = false
  }
  await GetAllItems(route.params.id.toString())
}
onMounted(async () => {
  await GetAllItems(route.params.id.toString())
})
async function deleteItem(val:boolean) {
  if(val){
  await DeleteItem(state.itemId)
  await GetAllItems(route.params.id.toString())
  }
  state.itemId='',
  state.isDeleted=false
}
async function editItem(ItemId: string) {
  state.dialog = true
  const Itemdata = await GetItem(ItemId)
  console.log(Itemdata)
  ;(state.itemId = Itemdata.id!),
    (state.title = Itemdata.title),
    (state.description = Itemdata.description!),
    (state.ItemType = Itemdata.type == ItemType.TICKET ? 'Ticket' : 'PR'),
    (state.itemUrl = Itemdata.url!),
    (state.number = Itemdata.number)
}
const form = ref()
function formatDate(datetime: Date) {
  const date = new Date(datetime)
  const year = date.getFullYear()
  const month = ('0' + (date.getMonth() + 1)).slice(-2)
  const day = ('0' + date.getDate()).slice(-2)
  return `${year}-${month}-${day}`
}
const date = ref()
watch(date, () => {
  if (date.value != '' && date.value != null) {
    filtereditems.value = Items.value.filter((x) => formatDate(x.createdOn!) == date.value)
  } else filtereditems.value = Items.value
})
</script>
<template>
  <Navbar />
  <v-container>
    <v-row>
      <v-col cols="12" lg="10" md="9" sm="12">
        <v-text-field type="date" color="primary" v-model="date"></v-text-field>
      </v-col>
      <v-col cols="12" lg="2" md="3" sm="12">
        <Button
          class="w-100 mt-3"
          :rounded="false"
          @click="state.dialog = true"
          variant="elevated"
          prepend-icon="mdi-plus"
          >Add New Item</Button
        >
      </v-col>
    </v-row>
    <div v-if="filtereditems.length == 0">
      <RecordNotFoundComponent />
    </div>
    <v-row v-else>
      <!-- <v-col cols="12">
        <Button onclick="history.back()">Back to Keeps</Button>
      </v-col> -->
      <v-col cols="12" lg="6" md="12" sm="12" v-for="item in filtereditems" :key="item.id" class="mb-10">
        <Card>
          <template #title>
            <v-row>
              <v-col cols="4" md="2">
               <a target="_blank" :href='item.url'> <v-chip class="bg-primary text-white row-pointer"
                  >{{ item.type == ItemType.TICKET ? '#' : '!' }} {{ item.number }}</v-chip></a>
              </v-col>
              <v-col cols="5" md="7">
                <p class="text-center">{{ item.title }}</p>
              </v-col>
              <v-col cols="3">
                <div class="d-flex justify-space-between float-end">
                  <v-menu>
                    <template v-slot:activator="{ props }">
                      <Button variant="text" color="" v-bind="props">
                        <v-icon color="primary">mdi-dots-vertical</v-icon>
                      </Button>
                    </template>
                    <v-list>
                      <v-list-item>
                        <v-list-item-title
                          ><Button variant="text" @click="editItem(item.id!)"
                            >Edit</Button
                          ></v-list-item-title
                        >
                        <v-list-item-title
                          ><Button variant="text" @click="()=>{state.isDeleted=true;state.itemId=item.id!}"
                            >Delete</Button
                          ></v-list-item-title
                        >
                      </v-list-item>
                    </v-list>
                  </v-menu>
                </div>
              </v-col>
            </v-row>
          </template>
          <template #text>
            <v-card-text>
              <span
                v-if="item.description == '' || item.description == null"
                class="text-grey font-italic"
                >No description provided
              </span>
              <span v-else>{{ item.description }}</span>
            </v-card-text>
          </template>
        </Card>
      </v-col>
    </v-row>
  </v-container>

  <ModalComponent :dialog="state.dialog" @close="state.dialog = false" :width="830">
    <template #title>
      <div class="text-left ml-4 mt-3">
        <Button @click="state.dialog = false" prepend-icon="mdi-arrow-left-circle">Back</Button>
      </div>
      <div class="text-center text-primary mt-2">
        {{ state.itemId != '' ? 'Edit Item' : 'Create New Item' }}
      </div>
    </template>

    <template #formSlot>
      <v-form ref="form">
        <v-container>
          <v-row>
            <v-col cols="12" md="2" sm="6">
              <v-menu transition="scale-transition">
                <template v-slot:activator="{ props }">
                  <v-select
                    label="Type"
                    :items="['Ticket', 'PR']"
                    variant="outlined"
                    v-model="state.ItemType"
                  ></v-select>
                </template>
                <v-list>
                  <v-list-item v-for="(item, i) in list" :key="i">
                    <v-list-item-title>{{ item.name }}</v-list-item-title>
                  </v-list-item>
                </v-list>
              </v-menu>
            </v-col>
            <v-col cols="12" md="4" sm="6">
              <TextFieldNumber
                label="Number"
                color="primary"
                v-model="state.number"
              ></TextFieldNumber>
            </v-col>
            <v-col cols="12" md="6" sm="9">
              <TextFieldText label="Item name" v-model="state.title" />
            </v-col>
            <v-col cols="12" md="12" sm="12">
              <TextFieldText label="Item URL" :is-required="false" v-model="state.itemUrl" />
            </v-col>
            <v-col cols="12">
              <v-textarea
                label="Description"
                color="primary"
                variant="outlined"
                v-model="state.description"
                clearable
              ></v-textarea>
            </v-col>
            <v-col cols="12" sm="12" md="12" lg="12">
              <v-file-input
                v-model="attachment"
                multiple
                label="File input"
                variant="outlined"
              ></v-file-input>
            </v-col>
            <v-col cols="12" sm="6" md="2" lg="2">
              <Button>To</Button>
            </v-col>
            <v-col cols="12" sm="6" md="4" lg="4">
              <Button>Discussed by</Button>
            </v-col>
          </v-row>
        </v-container>
      </v-form>
    </template>
    <template #actionBtn>
      <div class="mb-2">
        <v-row>
          <v-col>
            <Button
              width="100"
              @click="
                () => {
                  form.reset()
                }
              "
              >Clear</Button
            >
            <Button variant="elevated" width="100" @click="addItem">{{
              state.itemId != '' ? 'Update' : 'Create'
            }}</Button>
          </v-col>
        </v-row>
      </div>
    </template>
  </ModalComponent>
  <DeleteComponent :dialog="state.isDeleted" @deleteAction="deleteItem"></DeleteComponent>
</template>
<style scoped>
.row-pointer:hover {
  cursor: pointer;
}
</style>

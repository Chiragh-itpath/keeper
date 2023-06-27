<script setup lang="ts">
import { RouterEnum } from '@/enum/RouterEnum'
import Button from '@/components/ButtonComponent.vue'
import Card from '@/components/CardComponent.vue'
import { reactive } from 'vue'
import { ref } from 'vue'
import ModalComponent from '@/components/ModalComponent.vue'
import TextFieldText from '@/components/TextFieldText.vue'
import TextFieldEmail from '@/components/TextFieldEmail.vue'
import { useKeepStore } from '@/stores/KeepStore'
import type { Ikeep } from '@/Models/KeepModel'
import { onMounted } from 'vue'
import { storeToRefs } from 'pinia'
import { useRoute } from 'vue-router'
import { watch } from 'vue'
import { tagStore } from '@/stores/TagStore'
const { AddKeep, GetKeeps, DeleteKeep, Updatekeep, GetKeepById } = useKeepStore()
const { Keeps } = storeToRefs(useKeepStore())
const{GetByTagId}=tagStore()

const proid = ref()

const state = reactive({
  KeepId: '',
  keepName: '',
  tag: '',
  inviteEmail: [
    'rucha@gmail.com',
    'vishruti@gmail.com',
    'chirag@gmail.com',
    'nik@gmail.com',
    'khoda@gmail.com'
  ],
  dialog: false,
  openSnkbar: false,
  openInvite: false,
  email: '',
  snackbarMessage: ''
})

const form = ref()
const route = useRoute()
var filteredkeeps = ref(Keeps.value)
function formatDate(datetime: Date) {
  const date = new Date(datetime)
  const year = date.getFullYear()
  const month = ('0' + (date.getMonth() + 1)).slice(-2)
  const day = ('0' + date.getDate()).slice(-2)
  return `${year}-${month}-${day}`
}
watch(Keeps, () => {
  filteredkeeps.value = Keeps.value
})
let date = ref()
watch(date, () => {
  if (date.value != '' && date.value != null) {
    filteredkeeps.value = Keeps.value.filter((k) => formatDate(k.createdOn!) == date.value)
  } else {
    filteredkeeps.value = Keeps.value
  }
})
onMounted(async () => {
  proid.value = route.params.id.toString()
  await GetKeeps(proid.value)
})
async function CreateKeep(): Promise<void>  {
  if (state.KeepId == '') {
    const { valid } = await form.value.validate()
    if (!valid) return
    const keeps: Ikeep = {
      title: state.keepName,
      projectId: proid.value,
      tagTitle:state.tag
    }
    await AddKeep(keeps)
    form.value.reset()
    state.dialog = false
  } else {
    const keep: Ikeep = {
      id: state.KeepId,
      title: state.keepName,
      tagTitle:state.tag
    }
    await editkeep(state.KeepId)
    await Updatekeep(keep)
    state.KeepId = ''
    form.value.reset()
    state.dialog = false
  }
   await GetKeeps(proid.value)
}

async function deletekeep(keepId: string) {
  await DeleteKeep(keepId)
  await GetKeeps(proid.value)
}
async function editkeep(keepId: string) {
  state.dialog = true
  const data = await GetKeepById(keepId)
  const tagdata=await GetByTagId(data.tagId)
  state.keepName = data.title
  state.KeepId = data.id
  state.tag=tagdata.data.data?.title
}

function onEnter() {
  state.inviteEmail.push(state.email)
  state.email = ''
}
</script>
<template>
  <v-container>
    <v-row>
      <v-col cols="12" md="10" sm="12">
        <v-text-field color="primary" type="date" v-model="date"></v-text-field>
      </v-col>
      <v-col cols="12" md="2" sm="12" class="my-auto">
        <Button
          class="w-100"
          :rounded="false"
          @click="state.dialog = true"
          variant="elevated"
          prepend-icon="mdi-plus"
        >
          New Keep
        </Button>
      </v-col>
    </v-row>
    <v-row>
      <v-col
        v-for="(keep, index) in filteredkeeps"
        :key="index"
        cols="12"
        lg="3"
        md="12"
        sm="6"
        class="mb-3"
      >
        <Card>
          <template #title>
            <div class="position-relative text-grey-darken-4">
              {{ keep.title }}
              <v-btn class="position-absolute" style="right: 0" id="parent" variant="text" rounded>
                <v-icon> mdi-dots-vertical </v-icon>
                <v-menu activator="parent">
                  <v-list>
                    <v-list-item>
                      <v-list-item-title
                        ><Button variant="text" @click="editkeep(keep.id!)"
                          >Edit</Button
                        ></v-list-item-title
                      >
                      <v-list-item-title
                        ><Button variant="text" @click="deletekeep(keep.id!)"
                          >Delete</Button
                        ></v-list-item-title
                      >
                    </v-list-item>
                  </v-list>
                </v-menu>
              </v-btn>
            </div>
          </template>
          <template #actions>
            <Button variant="outlined"
              ><router-link :to="{ name: RouterEnum.ITEM }" class="link">Click</router-link></Button
            >
          </template>
        </Card>
      </v-col>
    </v-row>
  </v-container>
  <ModalComponent :dialog="state.dialog" @close="state.dialog = false">
    <template #title>
      <div class="text-left ml-4 mt-3">
        <Button @click="
          ()=>{
            state.dialog = false 
            form.reset() 
            state.KeepId = ''
            }
            "
           prepend-icon="mdi-arrow-left-circle">Back</Button>
      </div>
      <div class="text-center text-primary mt-2">Add New Keep</div>
    </template>

    <template #formSlot>
      <v-form ref="form">
        <v-container>
          <v-row>
            <v-col cols="12" md="8" sm="9">
              <TextFieldText label="Keep Name" v-model="state.keepName" />
            </v-col>
            <v-col cols="12" md="4" sm="3">
              <TextFieldText label="Tag" :is-required="false" v-model="state.tag" />
            </v-col>
            <v-col cols="12" sm="6" md="2" lg="2">
              <v-btn
                color="primary"
                variant="outlined"
                class="w-100"
                @click="state.openInvite = true"
                >Invite</v-btn
              >
            </v-col>
            <v-col cols="12" sm="6" md="10" lg="10">
              <span v-for="(selection, index) in state.inviteEmail" :key="selection">
                <v-chip closable v-if="index < 2" @click:close="state.inviteEmail.splice(index, 1)">
                  <span>{{ selection }}</span>
                </v-chip>
                <span v-if="index === 2" class="text-grey text-caption align-self-center">
                  (+{{ state.inviteEmail.length - 2 }} others)
                </span>
              </span>
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
            <Button variant="elevated" width="100" @click="CreateKeep">{{
              state.KeepId != '' ? 'Update' : 'Create'
            }}</Button>
          </v-col>
        </v-row>
      </div>
    </template>
  </ModalComponent>
  <ModalComponent :dialog="state.openInvite" @close="state.openInvite = false" :width="600">
    <template #title>
      <div class="text-primary mt-2">Invite People</div>
    </template>
    <template #formSlot>
      <v-form ref="form">
        <v-row>
          <v-row>
            <v-col cols="10" md="10" sm="10">
              <TextFieldEmail label="Email" color="primary" v-model="state.email" />
            </v-col>
            <v-col cols="2" md="2" sm="2">
              <v-avatar @click="onEnter" color="secondary" class="mt-2"
                ><v-icon icon="mdi-plus-thick" color="white"></v-icon
              ></v-avatar>
            </v-col>
          </v-row>
          <v-col cols="12">
            <v-sheet elevation="5" class="px-2" height="200px" width="auto">
              <div class="scroll">
                <v-row v-for="(email, index) in state.inviteEmail" :key="email" class="mt-2">
                  <v-col cols="3" sm="3" md="2" lg="2" class="d-flex justify-center">
                    <v-avatar color="secondary">{{ email.charAt(0) }}</v-avatar>
                  </v-col>
                  <v-col cols="6" sm="6" md="8" lg="8" class="d-flex align-center">
                    {{ email }}
                  </v-col>
                  <v-col cols="3" sm="3" md="2" lg="2" class="d-flex justify-center">
                    <v-icon
                      @click="
                        () => {
                          state.inviteEmail.splice(index, 1)
                        }
                      "
                      icon="mdi-minus-circle-outline"
                      size="large"
                    ></v-icon>
                  </v-col>
                </v-row>
              </div>
            </v-sheet>
          </v-col>
        </v-row>
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
                  state.inviteEmail.splice(0, state.inviteEmail.length)
                  state.openInvite = false
                }
              "
              >Cancle</Button
            >
            <Button variant="elevated" width="100" @click="state.openInvite = false">Invite</Button>
          </v-col>
        </v-row>
      </div>
    </template>
  </ModalComponent>
  <v-snackbar
    :timeout="2000"
    color="#1B5E20"
    elevation="20"
    location="bottom right"
    v-model="state.openSnkbar"
  >
    Saved Successfully!
  </v-snackbar>
</template>

<style scoped>
.link {
  text-decoration: none;
  color: black;
}

.scroll {
  max-height: 200px;
  overflow-y: scroll;
}
</style>

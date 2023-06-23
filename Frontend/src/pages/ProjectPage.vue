<script setup lang="ts">
import Button from '@/components/ButtonComponent.vue'
import Card from '@/components/CardComponent.vue'
import ModalComponent from '@/components/ModalComponent.vue'
import { ref } from 'vue'
import TextFieldText from '@/components/TextFieldText.vue'
import { reactive } from 'vue'
import { useProjectStore } from '@/stores/ProjectStore'
import type { IProject } from '@/Models/ProjectModel'
import { onMounted } from 'vue'
import { storeToRefs } from 'pinia'
import TextFieldEmail from '@/components/TextFieldEmail.vue'
import Snackbar from '@/components/SnackbarComponent.vue'
import { RouterEnum } from '@/enum/RouterEnum'
import { watch } from 'vue'
import type { Ref } from 'vue'
const state = reactive({
  projectId: '',
  projectName: '',
  tag: '',
  description: '',
  inviteEmail: [],
  dialog: false,
  openSnackbar: false,
  snackbarMessage: '',
  success: false,
  error: false,
  show: -1,
  openInvite: false,
  email: ''
})
const items: { title: string; icon: string; to: {} }[] = [
  {
    title: 'Edit',
    icon: 'mdi-edit',
    to: { path: '/EditProject' }
  },
  {
    title: 'Delete',
    icon: 'mdi-delete',
    to: { path: '/Projects' }
  }
]
const form = ref()

const { AddProject, GetProjects, UpdateProject, GetProjectById, DeleteProject } = useProjectStore()

const { Projects } = storeToRefs(useProjectStore())
let filterData = ref(Projects.value)
let date = ref()
watch(Projects, () => {
  filterData.value = Projects.value
})
onMounted(async () => {
  await GetProjects()
})
async function addProject(): Promise<void> {
  if (state.projectId == '') {
    const { valid } = await form.value.validate()
    if (!valid) return

    const project: IProject = {
      title: state.projectName,
      description: state.description,
      tagTitle: state.tag
    }
    await AddProject(project)
    form.value.reset()
    state.dialog = false
  } else {
    const project: IProject = {
      id: state.projectId,
      title: state.projectName,
      description: state.description
    }
    await editProject(state.projectId)
    await UpdateProject(project)
    state.projectId = ''
    form.value.reset()
    state.dialog = false
  }
}
function onEnter() {
  if (state.email.trim() != '') state.inviteEmail.push(state.email)
  state.email = ''
}
async function editProject(projectId: string) {
  state.dialog = true
  const data = await GetProjectById(projectId)
  console.log(data)
  state.projectName = data.title
  state.description = data.description
  state.projectId = projectId
}
async function deleteProject(projectId: string) {
  await DeleteProject(projectId)
}
function formatDate(datetime: Date) {
  const date = new Date(datetime)
  const year = date.getFullYear()
  const month = ('0' + (date.getMonth() + 1)).slice(-2)
  const day = ('0' + date.getDate()).slice(-2)
  return `${year}-${month}-${day}`
}
watch(date, () => {
  if (date.value != '' && date.value != null) {
    filterData.value = Projects.value.filter((p) => formatDate(p.createdOn!) == date.value)
  } else filterData.value = Projects.value
})
</script>
<template>
  <v-container>
    <v-row>
      <v-col cols="12" md="10" sm="12">
        <v-text-field color="primary" type="date" v-model="date" />
      </v-col>
      <v-col cols="12" md="2" sm="12" class="my-auto">
        <Button
          class="w-100"
          @click="state.dialog = true"
          :rounded="false"
          variant="elevated"
          prepend-icon="mdi-plus"
        >
          new folder
        </Button>
      </v-col>
    </v-row>
    <v-row>
      <v-col
        v-for="(project, index) in filterData"
        :key="index"
        cols="12"
        lg="3"
        md="4"
        sm="6"
        class="mb-3"
      >
        <Card>
          <template #title>
            <div class="position-relative text-grey-darken-4">
              {{ project.title }}
              <Button
                variant="text"
                color="text-light"
                @click="$router.push({ name: RouterEnum.KEEP, params: { id: project.id } })"
                class="position-absolute"
                style="left: 0"
                ><v-icon>mdi-note-multiple</v-icon>
                <v-tooltip activator="parent" location="top">keep</v-tooltip></Button
              >
              <v-btn class="position-absolute" style="right: 0" id="parent" variant="text" rounded>
                <v-icon> mdi-dots-vertical </v-icon>
                <v-menu activator="parent">
                  <v-list>
                    <v-list-item>
                      <v-list-item-title
                        ><Button variant="text" @click="editProject(project.id)"
                          >Edit</Button
                        ></v-list-item-title
                      >
                      <v-list-item-title
                        ><Button variant="text" @click="deleteProject(project.id)"
                          >Delete</Button
                        ></v-list-item-title
                      >
                    </v-list-item>
                  </v-list>
                </v-menu>
              </v-btn>
            </div>
          </template>
          <template #text>
            <v-card-text>
              {{ project.description }}
              <span v-if="project.description == ''" class="text-grey font-italic"
                >No description provided
              </span>
            </v-card-text>
          </template>
        </Card>
      </v-col>
    </v-row>
  </v-container>
  <ModalComponent :dialog="state.dialog" @close="state.dialog = false">
    <template #title>
      <div class="text-left ml-4 mt-3">
        <Button
          @click="
            () => {
              state.dialog = false
              form.reset()
              state.projectId = ''
            }
          "
          prepend-icon="mdi-arrow-left-circle"
          >Back</Button
        >
      </div>
      <div class="text-center text-primary mt-2">Create New Project</div>
    </template>

    <template #formSlot>
      <v-form ref="form">
        <v-container>
          <v-row>
            <v-col cols="12" md="8" sm="9">
              <TextFieldText label="Project Name" v-model="state.projectName" />
            </v-col>
            <v-col cols="12" md="4" sm="3">
              <TextFieldText label="Tag" :is-required="false" v-model="state.tag" />
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
            <v-col cols="12" sm="6" md="2" lg="2">
              <v-btn color="primary" variant="outlined" @click="state.openInvite = true"
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
            <Button variant="elevated" width="100" @click="addProject">{{
              state.projectId != '' ? 'Update' : 'Create'
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
              <v-avatar @click="onEnter" color="primary" class="mt-2"
                ><v-icon icon="mdi-plus-thick" color="white"></v-icon
              ></v-avatar>
            </v-col>
          </v-row>
          <v-col cols="12">
            <v-sheet elevation="5" class="px-2" height="200px" width="auto">
              <div class="scroll">
                <v-row v-for="(email, index) in state.inviteEmail" :key="email" class="mt-2">
                  <v-col cols="3" sm="3" md="2" lg="2" class="d-flex justify-center">
                    <v-avatar color="primary">{{ email.charAt(0) }}</v-avatar>
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
            <Button variant="elevated" :width="100" @click="state.openInvite = false"
              >Invite</Button
            >
          </v-col>
        </v-row>
      </div>
    </template>
  </ModalComponent>
  <Snackbar v-model="state.openSnackbar" :error="state.error">
    <v-icon v-if="state.error">mdi-alert</v-icon>
    <v-icon v-if="state.success">mdi-check</v-icon>
    {{ state.snackbarMessage }}
  </Snackbar>
</template>
<style scoped>
.scroll {
  max-height: 200px;
  overflow-y: scroll;
}
</style>

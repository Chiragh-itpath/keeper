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
import { tagStore } from '@/stores/TagStore'
import { useMailStore } from '@/stores/MailStore'
import { useUserStore } from '@/stores/UserStore'
import { watch } from 'vue'
import type { IMail } from '@/Models/MailModel'
import { useRouter, useRoute } from 'vue-router'
import RecordNotFoundComponent from '@/components/RecordNotFoundComponent.vue'
import { TagTypeEnum } from '@/enum/TagTypeEnum'
import { StatusType } from '@/enum/StatusType'
import Loader from '@/components/LoaderComponent.vue';
import DeleteComponent from '@/components/DeleteComponent.vue'
const { GetAll, GetByTagType, GetByTagTitle, TagForProject } = tagStore()
const{GetUserByEmail}=useUserStore()
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
  email: '',
  isLoading: true,
  isDeleted: false,
  isError:false,
  errorMsg:''
})

const form = ref()
const { AddProject, GetProjects, UpdateProject, GetProjectById, DeleteProject, GetProjectByTag } =
  useProjectStore()
const { GetByTagId } = tagStore()
const { Mail } = useMailStore()
const { Projects } = storeToRefs(useProjectStore())
const { Tags } = storeToRefs(tagStore())
let filterData = ref(Projects.value)
let date = ref()
const route = useRoute()
const router = useRouter()

watch(route, async () => {
  if (route.name == RouterEnum.PROJECT_BY_TAG) {
    filterData.value = await GetProjectByTag(route.params.id.toString())
  } else {
    await GetProjects()
    filterData.value = Projects.value
  }
})
async function setProjectData() {
  if (route.name == RouterEnum.PROJECT_BY_TAG) {
    filterData.value = await GetProjectByTag(route.params.id.toString())
  } else {
    await GetProjects()
    filterData.value = Projects.value
  }
}
watch(date, () => {
  if (date.value != '' && date.value != null) {
    filterData.value = Projects.value.filter((p) => formatDate(p.createdOn!) == date.value)
  } else{
    filterData.value = Projects.value
  } 
})
onMounted(async () => {
  if (
    route.name?.toString() == RouterEnum.PROJECT ||
    route.name?.toString() == RouterEnum.PROJECT_BY_TAG
    )
    await TagForProject()
    await GetProjects()
  filterData.value = Projects.value
  state.isLoading = false;
})
async function addProject(): Promise<void> {
  const { valid } = await form.value.validate()
  if (!valid) return
  let mailObj: IMail;
  if (state.inviteEmail.length > 0) {
    mailObj = {
      ToEmail: state.inviteEmail,
      Type:TagTypeEnum.PROJECT
    }
  }
  if (state.projectId == '') {
    state.dialog = false
    
    const project: IProject = {
      title: state.projectName,
      description: state.description,
      tagTitle: state.tag,
      mail:mailObj!
    }
    form.value.reset()
    const response = await AddProject(project)
    if (response.data.statusName == StatusType.SUCCESS) {
      state.openSnackbar = true
      state.snackbarMessage = response.data.message
    }
  } else {
    const project: IProject = {
      id: state.projectId,
      title: state.projectName,
      description: state.description,
      tagTitle: state.tag,
      mail:mailObj!
    }
    await editProject(state.projectId)
    await UpdateProject(project)
    state.projectId = ''
    state.dialog = false
    form.value.reset()
  }
  
  // if (state.inviteEmail.length > 0) {
  //   let mailObj: IMail = {
  //     ToEmail: state.inviteEmail,
  //     Type:TagTypeEnum.PROJECT,
  //     TypeId:state.projectId
  //   }
  //   await Mail(mailObj)
  // }
  state.inviteEmail = []
  await TagForProject()
  setProjectData()
}
async function onEnter() {
  if (state.email.trim() != ''){
    const response=await GetUserByEmail(state.email)
    if(response!=null){
      state.inviteEmail.push(state.email)
    }
    else{
      state.isError=true
      state.errorMsg='Email is not registered in this application';
      debugger
      setTimeout(() => {
        state.isError=false 
        state.errorMsg=''
      },3000)
    }
  } 
  state.email = ''
}
async function editProject(projectId: string) {
  state.dialog = true
  const data = await GetProjectById(projectId)
  const tagdata = await GetByTagId(data.tagId)
  state.projectName = data.title
  state.description = data.description
  state.projectId = projectId
  state.tag = tagdata.data.data?.title
}
async function deleteProject(val: boolean) {
  if (val) {
    await DeleteProject(state.projectId)
    await TagForProject()
    setProjectData()
  }
  state.projectId='';
  state.isDeleted=false
}
function formatDate(datetime: Date) {
  const date = new Date(datetime)
  const year = date.getFullYear()
  const month = ('0' + (date.getMonth() + 1)).slice(-2)
  const day = ('0' + date.getDate()).slice(-2)
  return `${year}-${month}-${day}`
}
</script>
<template>
 <Loader v-if="state.isLoading" /> 
  <v-container>
    <v-row>
      <v-col cols="12" md="10" sm="12">
        <v-text-field color="primary" type="date" v-model="date" />
      </v-col>
      <v-col cols="12" md="2" sm="12" class="my-auto">
        <Button class="w-100" @click="state.dialog = true" :rounded="false" variant="elevated" prepend-icon="mdi-plus">
          new folder
        </Button>
      </v-col>
    </v-row>
    <div v-if="filterData.length == 0 && !state.isLoading">
      <RecordNotFoundComponent title="No project with this date" icon="mdi-note-remove-outline" v-if="date!=null"></RecordNotFoundComponent>
      <RecordNotFoundComponent icon="mdi-folder-file-outline" title="Projects you add appear here" v-else></RecordNotFoundComponent>
    </div>
    <v-row class="ma-6" v-else>
      <v-col cols="12">
        <Button @click="() => router.push({ name: RouterEnum.PROJECT })" v-if="route.fullPath.indexOf('Tag') > 0">
          All Projects
        </Button>
      </v-col>
      <v-col v-for="(project, index) in filterData" :key="index" cols="12" lg="3" md="4" sm="6" class="mb-3">
        <Card>
          <template #title>
            <div class="position-relative text-grey-darken-4">
              <span @click="$router.push({ name: RouterEnum.KEEP, params: { id: project.id } })">{{
                project.title
              }}</span>
              <v-btn class="position-absolute" style="right: 0" id="parent" variant="text" rounded>
                <v-icon> mdi-dots-vertical </v-icon>
                <v-menu activator="parent">
                  <v-list>
                    <v-list-item>
                      <v-list-item-title><Button variant="text"
                          @click="editProject(project.id!)">Edit</Button></v-list-item-title>
                      <v-list-item-title><Button variant="text"
                          @click="()=>{state.isDeleted = true; state.projectId=project.id!}">Delete</Button></v-list-item-title>
                    </v-list-item>
                  </v-list>
                </v-menu>
              </v-btn>
            </div>
          </template>
          <template #text>
            <v-card-text @click="$router.push({ name: RouterEnum.KEEP, params: { id: project.id } })">
              {{ project.description }}
              <span v-if="project.description == '' || project.description == null" class="text-grey font-italic">No
                description provided
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
        <Button @click="() => {
            state.dialog = false
            form.reset()
            state.projectId = ''
            state.inviteEmail=[]
          }
          " prepend-icon="mdi-arrow-left-circle">Back</Button>
      </div>
      <div class="text-center text-primary mt-2">
        {{ state.projectId != '' ? 'Edit Project' : 'Create New Project' }}
      </div>
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
              <v-textarea label="Description" color="primary" variant="outlined" v-model="state.description"
                clearable></v-textarea>
            </v-col>
            <v-col cols="12" sm="6" md="2" lg="2">
              <v-btn color="primary" variant="outlined" @click="state.openInvite = true">Invite</v-btn>
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
            <Button width="100" @click="() => {
                form.reset()
              }
              ">Clear</Button>
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
      <v-form>
        <v-row>
          <v-row>
            <v-col cols="10" md="10" sm="10">
              <TextFieldEmail label="Email" color="primary" v-model="state.email" :error="state.isError"
    :error-messages="state.errorMsg"/>
            </v-col>
            <v-col cols="2" md="2" sm="2">
              <v-avatar @click="onEnter" color="primary" class="mt-2"><v-icon icon="mdi-plus-thick"
                  color="white"></v-icon></v-avatar>
            </v-col>
          </v-row>
          <v-col cols="12">
            <v-sheet class="px-2  border-color" height="200px" width="auto" rounded outlined>
              <div class="scroll">
                <v-row v-for="(email, index) in state.inviteEmail" :key="email" class="mt-2">
                  <v-col cols="3" sm="3" md="2" lg="2" class="d-flex justify-center">
                    <v-avatar color="primary">{{ email.charAt(0) }}</v-avatar>
                  </v-col>
                  <v-col cols="6" sm="6" md="8" lg="8" class="d-flex align-center">
                    {{ email }}
                  </v-col>
                  <v-col cols="3" sm="3" md="2" lg="2" class="d-flex justify-center">
                    <v-icon @click="() => {
                        state.inviteEmail.splice(index, 1)
                      }
                      " icon="mdi-minus-circle-outline" size="large"></v-icon>
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
            <Button width="100" @click="() => {
                state.inviteEmail.splice(0, state.inviteEmail.length)
                state.openInvite = false
              }
              ">Cancle</Button>
            <Button variant="elevated" :width="100" @click="state.openInvite = false">Invite</Button>
          </v-col>
        </v-row>
      </div>
    </template>
  </ModalComponent>
  <Snackbar v-model="state.openSnackbar" :error="state.error" color="primary">
    <v-icon v-if="state.error">mdi-alert</v-icon>
    <v-icon v-if="state.success">mdi-check</v-icon>
    {{ state.snackbarMessage }}
  </Snackbar>
  <DeleteComponent :dialog="state.isDeleted" @deleteAction="deleteProject"></DeleteComponent>
</template>

<style scoped>
.scroll {
  max-height: 200px;
  overflow-y: scroll;
}
.border-color {
  border: 1px solid gray; 
}
</style>

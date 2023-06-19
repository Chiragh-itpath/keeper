<script setup lang="ts">
import Button from '@/components/ButtonComponent.vue';
import Card from '@/components/CardComponent.vue';
import ModalComponent from "@/components/ModalComponent.vue";
import { ref } from 'vue';
import TextFieldText from "@/components/TextFieldText.vue";
import { reactive } from 'vue';
import { useProjectStore } from "@/stores/ProjectStore";
import type { IProject } from '@/Models/ProjectModel';
import { StatusType } from '@/enum/StatusType';
import { useProjectStore } from "@/stores/ProjectStore";
import type { IProject } from '@/Models/ProjectModel';
import { StatusType } from '@/enum/StatusType';


const state = reactive({
    projectName: '',
    tagName:'',
    description: '',
    value: [''],
    dialog: false,
    openSnackbar: false,
    snackbarMessage:''
})
const form = ref()

const {AddProject}=useProjectStore();
async function addProject():Promise<void>{
    const{valid}=await form.value.validate();
    if(!valid)
    return

    const project:IProject={
        Title:state.projectName,
        Description:state.description,     
    }
    const response= await AddProject(project);
    try{
        if(response.data.statusName!=StatusType.SUCCESS){
            state.openSnackbar=true;
        }
        else{
            console.log(response);           
            state.openSnackbar=true;
            state.snackbarMessage=response.data.message;
            form.value.reset()
        }
    }
    catch(e){
        state.openSnackbar=true;
        state.snackbarMessage="Error"
    }
}
 function onEnter(){
    state.inviteEmail.push(state.email);
     state.email=''
}

</script>
<template>
    <v-container>
        <v-row>
            <v-col cols="12" md="10" sm="12">
                <v-text-field color="primary" type="date"></v-text-field>
            </v-col>
            <v-col cols="12" md="2" sm="12" class="my-auto">
                <Button class="w-100" @click="state.dialog = true" :rounded="false" variant="elevated"
                    prepend-icon="mdi-plus">
                    new folder
                </Button>
            </v-col>
        </v-row>
        <v-row>
            <v-col v-for="item in 1" :key="item" cols="12" lg="3" md="4" sm="6">
                <router-link to="/Projects" class="text-decoration-none">
                    <Card>
                        <template #title>
                            project {{ item }}
                        </template>
                    </Card>
                </router-link>
            </v-col>
        </v-row>
    </v-container>
    <ModalComponent :dialog="state.dialog" @close="state.dialog = false">
        <template #title>
            <div class="text-left ml-4 mt-3"><Button @click="state.dialog = false"
                    prepend-icon="mdi-arrow-left-circle">Back</Button></div>
            <div class="text-center text-primary mt-2">
                Create New Project
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
                            <TextFieldText label="Tag" :is-required="false" v-model="state.tagName" />
                        </v-col>
                        <v-col cols="12">
                            <v-textarea label="Description" color="primary" variant="outlined" v-model="state.description"
                                clearable></v-textarea>
                        </v-col>
                        <v-col cols="12" sm="6" md="2" lg="2">
                            <v-btn color="primary" variant="outlined" class="w-100" @click="state.openInvite=true">Invite</v-btn>
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
                        <Button width="100" @click="() => { form.reset() }">Clear</Button>
                        <Button variant="elevated" width="100" @click="addProject">Create</Button>
                    </v-col>
                </v-row>
            </div>
        </template>
    </ModalComponent>
    <ModalComponent :dialog="state.openInvite" @close="state.openInvite = false" :width="600">
        <template #title>
            <div class="text-primary mt-2">
                Invite People
            </div>
        </template>
        <template #formSlot>
            <v-form ref="form">
                    <v-row>
                        <v-row>
                            <v-col cols="10" md="10" sm="10">
                                <TextFieldEmail label="Email" color="primary" v-model="state.email"/>
                            </v-col>
                            <v-col cols="2" md="2" sm="2">
                                <v-avatar @click="onEnter" color="secondary" class="mt-2"><v-icon icon="mdi-plus-thick" color="white"></v-icon></v-avatar>
                            </v-col>
                        </v-row>
                        <v-col cols="12"> 
                                <v-sheet elevation="5" class="px-2" height="200px" width="auto">
                            <div class="scroll">
                                <v-row v-for="(email,index) in state.inviteEmail" :key="email" class="mt-2">
                                    <v-col cols="3" sm="3" md="2" lg="2" class="d-flex justify-center" >
                                        <v-avatar  color="secondary" >{{ email.charAt(0)}}</v-avatar>
                                    </v-col>
                                    <v-col cols="6" sm="6" md="8" lg="8" class="d-flex align-center" >
                                       {{ email }}
                                    </v-col>
                                    <v-col cols="3" sm="3" md="2" lg="2" class="d-flex justify-center">                                      
                                        <v-icon @click="()=>{state.inviteEmail.splice(index,1)}" icon="mdi-minus-circle-outline" size="large"></v-icon>
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
                        <Button width="100" @click="()=>{state.inviteEmail.splice(0,state.inviteEmail.length); state.openInvite=false}">Cancle</Button>
                        <Button variant="elevated" width="100" @click="state.openInvite=false">Invite</Button>
                    </v-col>
                </v-row>
            </div>
        </template>
    </ModalComponent>
    <v-snackbar :timeout="2000" color="#1B5E20" elevation="20" location="bottom right" v-model="state.openSnkbar">
        Saved Successfully!

    <v-snackbar :timeout="2000" color="#" elevation="20" location="bottom right" v-model="state.openSnackbar">
        {{ state.snackbarMessage }}
    </v-snackbar>
</template>
<style scoped>
.scroll {
  max-height: 200px;
  overflow-y: scroll;
}
</style>

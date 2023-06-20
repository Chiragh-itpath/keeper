import type { IProject } from '@/Models/ProjectModel';
import { Insert, GetById, Delete, Update, GetAll } from '@/Services/ProjectService'
import { defineStore, storeToRefs } from 'pinia';
import { useUserStore } from "@/stores/UserStore";
import { ref, type Ref } from 'vue';

export const useProjectStore = defineStore('ProjectStore', () => {
    const { User } = storeToRefs(useUserStore());
    const Projects: Ref<IProject[]> = ref([])
    async function AddProject(project: IProject): Promise<any> {
        project.createdBy = User.value!.id
        await Insert(project)
        await GetProjects();
    }
    async function GetProjectById(ProjectId:string):Promise<any>{
        return await GetById(ProjectId)
    }
    async function GetProjects():Promise<any> {
        const projects = await GetAll(User.value!.id)
        Projects.value = projects.data.data
    }
    async function DeleteProject(ProjectId:string):Promise<any>{
        return await Delete(ProjectId)
    }
    async function UpdateProject(Project:IProject):Promise<any>{
        return await Update(Project)
    }
    return{
        AddProject,
        GetProjectById,
        GetProjects,
        DeleteProject,
        UpdateProject,
        Projects  
    }
})
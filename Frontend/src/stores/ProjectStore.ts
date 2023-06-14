import type { IProject } from '@/Models/ProjectModel';
import type { IProjectUpdate } from '@/Models/ProjectUpdateModel';
import{Insert,GetById,Delete,Update,GetAll} from '@/Services/ProjectService'
import{defineStore} from 'pinia';
export const useProjectStore=defineStore('ProjectStore',()=>{
    async function AddProject(project:IProject):Promise<any>{
        return await Insert(project)
    }
    async function GetProjectById(ProjectId:string):Promise<any>{
        return await GetById(ProjectId)
    }
    async function GetProjects(UserId:string):Promise<any> {
        return await GetAll(UserId)
    }
    async function DeleteProject(ProjectId:string):Promise<any>{
        return await Delete(ProjectId)
    }
    async function UpdateProject(Project:IProjectUpdate):Promise<any>{
        return await Update(Project)
    }
    return{
        AddProject,
        GetProjectById,
        GetProjects,
        DeleteProject,
        UpdateProject  
    }
})
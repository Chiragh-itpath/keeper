import type { IProject } from '@/Models/ProjectModel';
import { Insert, GetById, Delete, Update, GetAll } from '@/Services/ProjectService'
import { defineStore, storeToRefs } from 'pinia';

import { useUserStore } from "@/stores/UserStore";
import { Guid } from 'guid-typescript';

export const useProjectStore = defineStore('ProjectStore', () => {
    const { User } = storeToRefs(useUserStore());
    
    async function AddProject(project: IProject): Promise<any> {
        project.CreatedBy = Guid.parse((User.value!.id).toString())       
        return await Insert(project)
    }
    async function GetProjectById(ProjectId: string): Promise<any> {
        return await GetById(ProjectId)
    }
    async function GetProjects(UserId: string): Promise<any> {
        return await GetAll(UserId)
    }
    async function DeleteProject(ProjectId: string): Promise<any> {
        return await Delete(ProjectId)
    }
    async function UpdateProject(Project: IProject): Promise<any> {
        return await Update(Project)
    }
    return {
        AddProject,
        GetProjectById,
        GetProjects,
        DeleteProject,
        UpdateProject
    }
})
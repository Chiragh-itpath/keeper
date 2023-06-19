import type { IProject } from '@/Models/ProjectModel';
import { Insert, GetById, Delete, Update, GetAll } from '@/Services/ProjectService'
import { defineStore, storeToRefs } from 'pinia';
import { useTagStore } from "@/stores/TagStore";
import { useUserStore } from "@/stores/UserStore";
import { Guid } from 'guid-typescript';
import type { ITag } from '@/Models/TagModel';
import { TagTypeEnum } from '@/enum/TagTypeEnum';
export const useProjectStore = defineStore('ProjectStore', () => {
    const { User } = storeToRefs(useUserStore());
    const TagStore = useTagStore();
    async function AddProject(project: IProject): Promise<any> {
        const Tags = await TagStore.GetAllTags();
        project.CreatedBy = Guid.parse((User.value!.id).toString())
        if (Tags != undefined) {
            const tag = Tags.find(tag => tag.Title == project.TagTitle && tag.Type == TagTypeEnum.PROJECT)
            if (tag == undefined) {
                const tag: ITag = {
                    Title: project.TagTitle,
                    Type: TagTypeEnum.PROJECT
                }
                await TagStore.Add(tag)
            }
        } else {
            const tag: ITag = {
                Title: project.TagTitle,
                Type: TagTypeEnum.PROJECT
            }
            await TagStore.Add(tag)
        }

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
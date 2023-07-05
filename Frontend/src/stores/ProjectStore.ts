import type { IProject } from '@/Models/ProjectModel'
import { Insert, GetById, Delete, Update, GetAll, GetByTag } from '@/Services/ProjectService'
import { defineStore, storeToRefs } from 'pinia'
import { useUserStore } from '@/stores/UserStore'
import { ref, type Ref } from 'vue'

export const useProjectStore = defineStore('ProjectStore', () => {
  const { User } = storeToRefs(useUserStore())
  const Projects: Ref<IProject[]> = ref([])
  async function AddProject(project: IProject): Promise<any> {
    project.createdBy = User.value!.id
    return await Insert(project)
  }
  async function GetProjectById(ProjectId: string): Promise<any> {
    return await GetById(ProjectId)
  }
  async function GetProjects(): Promise<any> {
    const projects = await GetAll(User.value!.id)
    Projects.value = projects.data.data
  }
  async function GetProjectByTag(TagId: string): Promise<any> {
    const UserId = User.value!.id
    const projects = await GetByTag(UserId, TagId)
    Projects.value = projects
    return projects
  }
  async function DeleteProject(ProjectId: string): Promise<any> {
    await Delete(ProjectId)
  }
  async function UpdateProject(Project: IProject): Promise<any> {
    Project.updatedBy = User.value!.id
    await Update(Project)
    await GetProjects()
  }
  return {
    AddProject,
    GetProjectById,
    GetProjects,
    GetProjectByTag,
    DeleteProject,
    UpdateProject,
    Projects
  }
})

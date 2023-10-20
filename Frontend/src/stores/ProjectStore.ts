import { computed, ref, type Ref } from 'vue'
import { defineStore } from 'pinia'
import type { IProject, IAddProject, IEditProject } from '@/Models/ProjectModels'
import { Insert, GetAll, Update, Delete, GetAllShared } from '@/Services/ProjectService'
import { dateHelper } from '@/Services/HelperFunction'

const ProjectStore = defineStore('ProjectStore', () => {
    const AllProjects: Ref<IProject[]> = ref([])
    const Projects: Ref<IProject[]> = ref([])

    const ProjectTags = computed(() => {
        const tags = AllProjects.value.map((x) => x.tag)
        return [...new Set(tags)]
    })
    const GetSingalProject = (id: string): IProject | undefined => {
        const project = Projects.value.find((x) => x.id == id)
        if (project) {
            return project
        }
    }

    const FindIndex = (id: string): number => AllProjects.value.findIndex((x) => x.id == id)

    const AddProject = async (addProject: IAddProject): Promise<any> => {
        const response = await Insert(addProject)
        if (response) {
            AllProjects.value.push(response)
        }
    }

    const getProjects = async (): Promise<void> => {
        AllProjects.value = []
        const response = await GetAll()
        if (!response) {
            return
        }
        AllProjects.value = response
        Projects.value = AllProjects.value
    }
    const FetchProjects = () => {
        Projects.value = AllProjects.value
    }

    const FetchSharedProjects = async (): Promise<void> => {
        const response = await GetAllShared()
        AllProjects.value = []
        if (response) {
            AllProjects.value = response
        }
        Projects.value = AllProjects.value
    }

    const UpdateProject = async (editProject: IEditProject): Promise<void> => {
        const response = await Update(editProject)
        if (response) {
            const index = FindIndex(editProject.id)
            Projects.value.splice(index, 1, response)
        }
    }

    const DeleteProject = async (id: string): Promise<void> => {
        const response = await Delete(id)
        if (response) {
            const index = FindIndex(id)
            if (index !== -1) AllProjects.value.splice(index, 1)
        }
    }

    const FilterByDate = (date: string): void => {
        Projects.value = AllProjects.value.filter((x) => {
            return dateHelper(date) == dateHelper(x.createdOn)
        })
    }

    const FilterByTag = (tag: string): void => {
        Projects.value = AllProjects.value.filter((x) => x.tag == tag)
    }

    const SingleProject = (id: string) => AllProjects.value.find((x) => x.id == id)

    return {
        Projects,
        ProjectTags,
        AddProject,
        FetchProjects,
        GetSingalProject,
        UpdateProject,
        DeleteProject,
        FetchSharedProjects,
        FilterByDate,
        FilterByTag,
        getProjects,
        SingleProject
    }
})
export { ProjectStore }

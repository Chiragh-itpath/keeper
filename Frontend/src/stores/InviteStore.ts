import { ref, type Ref } from 'vue'
import { defineStore } from 'pinia'
import type { IInvitedKeep, IInvitedProject } from '@/Models/InviteModels'
import type { Collaborators } from '@/Models/Collaborators'
import {
    InviteToProject,
    GetAllInvitedProject,
    ResponseToProjectInvite,
    GetAllInvitedKeeps,
    InviteToKeep,
    ResponseToKeepInvite,
    ProjectCollaborators,
    KeepCollaborators
} from '@/Services/InviteService'

const InviteStore = defineStore('inviteStore', () => {
    const InvitedProjectList: Ref<IInvitedProject[]> = ref([])
    const InvitedKeepList: Ref<IInvitedKeep[]> = ref([])
    const InviteUsersToProject = async (projectId: string, emails: string[]) => {
        await InviteToProject({
            projectId,
            emails
        })
    }
    const FetchInvitedProjects = async () => {
        const response = await GetAllInvitedProject()
        if (response) {
            InvitedProjectList.value = response
        }
    }
    const ProjectInviteResponse = async (inviteId: string, inviteResponse: boolean) => {
        await ResponseToProjectInvite({
            inviteId,
            response: inviteResponse
        })
    }
    const FetchInvitedKeeps = async () => {
        const response = await GetAllInvitedKeeps()
        if (response) {
            InvitedKeepList.value = response
        }
    }
    const InviteUsersToKeep = async (keepId: string, projectId: string, emails: string[]) => {
        console.log(projectId)
        await InviteToKeep({
            keepId,
            projectId,
            emails
        })
    }
    const keepInviteResponse = async (inviteId: string, inviteResponse: boolean) => {
        await ResponseToKeepInvite({
            inviteId,
            response: inviteResponse
        })
    }
    const GetProjectCollaborators = async (projectId: string): Promise<Collaborators[]> => {
        const response = await ProjectCollaborators(projectId)
        if (response) {
            return response
        }
        return []
    }
    const GetKeepCollaborators = async (keepId: string): Promise<Collaborators[]> => {
        const response = await KeepCollaborators(keepId)
        if (response) {
            return response
        }
        return []
    }
    return {
        InvitedProjectList,
        InvitedKeepList,
        InviteUsersToProject,
        FetchInvitedProjects,
        ProjectInviteResponse,
        FetchInvitedKeeps,
        InviteUsersToKeep,
        keepInviteResponse,
        GetProjectCollaborators,
        GetKeepCollaborators
    }
})

export { InviteStore }

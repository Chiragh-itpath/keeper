import { http } from '@/config/ApiClient'
import type { Collaborators } from '@/Models/Collaborators'
import type {
    IInvitedKeep,
    IInvitedProject,
    IKeepInvite,
    IProjectInvite,
    InviteResponse
} from '@/Models/InviteModels'

const InviteToProject = async (projectInvite: IProjectInvite): Promise<void> => {
    await http.post('Invite/InviteToProject', projectInvite)
}
const ResponseToProjectInvite = async (inviteResponse: InviteResponse): Promise<void> => {
    await http.post('Invite/ProjectInviteResponse', inviteResponse)
}
const GetAllInvitedProject = async (): Promise<IInvitedProject[] | null> => {
    const response: IInvitedProject[] = await http.get('Invite/AllInvitedProjects')
    return response
}
const InviteToKeep = async (keepInvite: IKeepInvite): Promise<void> => {
    await http.post('Invite/InviteToKeep', keepInvite)
}
const ResponseToKeepInvite = async (inviteResponse: InviteResponse): Promise<void> => {
    await http.post('Invite/keepInviteResponse', inviteResponse)
}
const GetAllInvitedKeeps = async (): Promise<IInvitedKeep[] | null> => {
    const response: IInvitedKeep[] = await http.get('Invite/InvitedKeeps')
    return response
}
const ProjectCollaborators = async (projectId: string): Promise<Collaborators[] | null> => {
    const response: Collaborators[] = await http.get(
        `Invite/ProjectCollaborators?ProjectId=${projectId}`
    )
    return response
}
const KeepCollaborators = async (keepId: string): Promise<Collaborators[] | null> => {
    const response: Collaborators[] = await http.get(`Invite/KeepCollaborators?keepId=${keepId}`)
    return response
}
export {
    InviteToProject,
    ResponseToProjectInvite,
    GetAllInvitedProject,
    InviteToKeep,
    ResponseToKeepInvite,
    GetAllInvitedKeeps,
    ProjectCollaborators,
    KeepCollaborators
}

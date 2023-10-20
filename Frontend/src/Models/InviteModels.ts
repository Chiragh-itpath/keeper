interface IInvited {
    name: string
    email: string
}
interface IInvitedKeep extends IInvited {
    keepId: string
    
}
interface IInvitedProject extends IInvited{
    projectId: string
}

interface IProjectInvite {
    projectId: string
    emails: string[]
}
interface IKeepInvite extends IProjectInvite {
    keepId: string
    
}


interface InviteResponse {
    inviteId: string
    response: boolean
}
export type { IInvitedKeep, IInvitedProject, IKeepInvite, IProjectInvite, InviteResponse }

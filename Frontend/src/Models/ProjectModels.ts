interface IAddProject {
    title: string
    description: string
    tag: string
}

interface IEditProject extends IAddProject {
    id: string
}
interface IProject extends IAddProject {
    id: string
    createdBy: string
    updatedBy: string
    createdOn: string
    updatedOn: string
    isShared: boolean
}

export type { IAddProject, IEditProject, IProject }

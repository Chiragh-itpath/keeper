interface IAddKeep {
    title: string
    projectId: string
    tag: string
}
interface IEditKeep extends IAddKeep {
    id: string
}
interface IKeep extends IAddKeep {
    id: string
    createdBy: string
    updatedBy: string
    createdOn: string
    updatedOn: string
}

export type { IAddKeep, IEditKeep, IKeep }

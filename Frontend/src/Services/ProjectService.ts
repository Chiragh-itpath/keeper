import { http } from '@/config/ApiClient'
import type { IAddProject, IEditProject, IProject } from '@/Models/ProjectModels'

const Insert = async (Project: IAddProject): Promise<IProject | null> => {
    const response: IProject = await http.post('Project', Project)
    return response
}
const GetById = async (ProjectId: string): Promise<IProject | null> => {
    const response: IProject = await http.get(`Project/${ProjectId}`)
    return response
}
const GetAll = async (): Promise<IProject[] | null> => {
    const response: IProject[] = await http.get('Project')
    return response
}
const Update = async (Project: IEditProject): Promise<IProject | null> => {
    const response: IProject = await http.put('Project', Project)
    return response
}
const Delete = async (ProjectId: string): Promise<boolean> => {
    const res = await http.delete(`Project/${ProjectId}`)
    return res != null
}

const GetAllShared = async (): Promise<IProject[] | null> => {
    const response: IProject[] = await http.get('Project/Shared')
    return response
}
export { Insert, GetById, GetAll, Update, Delete, GetAllShared }

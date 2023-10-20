import { http } from '@/config/ApiClient'
import type { IAddKeep, IEditKeep, IKeep } from '@/Models/KeepModels'

const GetAll = async (projectId: string): Promise<IKeep[] | null> => {
    const response: IKeep[] = await http.get(`Keep?ProjectId=${projectId}`)
    return response
}
const GetById = async (keepId: string): Promise<IKeep | null> => {
    const response: IKeep = await http.get(`Keep/${keepId}`)
    return response
}
const Insert = async (addKeep: IAddKeep): Promise<IKeep | null> => {
    console.log(addKeep)
    const response: IKeep = await http.post('Keep/', addKeep)
    return response
}
const Update = async (editKeep: IEditKeep): Promise<IKeep | null> => {
    const response: IKeep = await http.put('Keep/', editKeep)
    return response
}
const Delete = async (keepId: string): Promise<boolean> => {
    const response = await http.delete(`Keep/${keepId}`)
    return response != null
}

export { GetAll, GetById, Insert, Update, Delete }

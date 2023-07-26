import { http } from '@/GlobalConfig/ApiClient'
import type { Ikeep } from '@/Models/KeepModel'

export async function Insert(Keep: Ikeep): Promise<any> {
  try {
    const response = await http.post('/Keep', Keep)
    return response
  } catch (e) {
    console.log(e)
    return e
  }
}
export async function Update(keep: Ikeep): Promise<any> {
  try {
    const response = await http.put('/Keep', keep)
    return response
  } catch (e) {
    console.log(e)
    return e
  }
}
export async function Delete(KeepId: string): Promise<any> {
  try {
    const response = await http.delete(`/Keep/${KeepId}`)
    return response
  } catch (e) {
    console.log(e)
    return e
  }
}
export async function GetAll(ProjectId: string,UserId:string): Promise<any> {
  try {
    // const response = await http.get(`/Keep?ProjectId=${ProjectId}/${UserId}`)
    const response = await http.get(`/Keep/${ProjectId}/${UserId}`)
    return response
  } catch (e) {
    console.log(e)
    return e
  }
}
export async function GetById(KeepId: string): Promise<any> {
  try {
    const response = await http.get(`/Keep/${KeepId}`)
    return response.data.data
  } catch (e) {
    console.log(e)
    return e
  }
}
export async function GetByTag(UserId: string, TagId: string): Promise<any> {
  try {
    const response = await http.get(`/Keep/Tag/${UserId}/${TagId}`)
    return response.data.data
  } catch (e) {
    console.log(e)
    return e
  }
}

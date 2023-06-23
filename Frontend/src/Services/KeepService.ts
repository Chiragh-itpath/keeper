import { http } from '@/GlobalConfig/ApiClient'
import type { Ikeep } from '@/Models/KeepModel'

export async function Insert(Keep: Ikeep): Promise<any> {
  try {
    console.log(Keep)
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
export async function GetAll(ProjectId: string): Promise<any> {
  try {
    const response = await http.get(`/Keep?ProjectId=${ProjectId}`)
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

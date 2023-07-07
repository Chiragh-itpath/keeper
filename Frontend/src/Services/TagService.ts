import type { ITag } from '@/Models/TagModel'
import axios, { AxiosError, type AxiosResponse } from 'axios'
import type { TagTypeEnum } from '@/enum/TagTypeEnum'
import { http } from '@/GlobalConfig/ApiClient'
export async function Get(): Promise<[AxiosResponse| null,AxiosError | null ]> {
  try {
    const response = await http.get('Tag')
    return [response,null]
  } catch (error: any) {
    return [null,error]
  }
}
export async function GetById(tagId: string): Promise<any> {
  try {
    return await http.get(`Tag/${tagId}`)
  } catch (error) {
    console.log(error)
  }
}
export async function GetByType(tagType: TagTypeEnum): Promise<any> {
  try {
    return await http.get(`Tag/Type/${tagType}`)
  } catch (error) {
    console.log(error)
  }
}

export async function GetByTitle(title: string): Promise<any> {
  try {
    let res = await http.get(`Tag/Title/${title}`)
    return res.data.data
  } catch (error) {
    console.log(error)
  }
}
export async function GetForProject(userid: string): Promise<any> {
  try {
    debugger
    let res = await http.get(`Tag/Project/${userid}`)
    return res.data.data
  } catch (error) {
    console.log(error)
  }
}
export async function GetForKeeps(userid: string,projectId:string): Promise<any> {
  try {
    debugger
    let res = await http.get(`Tag/Keep/${userid}/${projectId}`)
    return res.data.data
  } catch (error) {
    console.log(error)
  }
}
export async function Post(tag: ITag): Promise<any> {
  try {
    return await http.post(`Tag`, tag)
  } catch (error) {
    console.log(error)
  }
}

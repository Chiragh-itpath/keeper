import type { ITag } from '@/Models/TagModel'
import axios from 'axios'
import type { TagTypeEnum } from '@/enum/TagTypeEnum'
import { http } from '@/GlobalConfig/ApiClient'
export async function Get(): Promise<any> {
  try {
    return await http.get('Tag')
  } catch (error) {
    console.log(error)
  }
}
export async function GetById(tagId:string): Promise<any> {
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
    let res=await http.get(`Tag/Title/${title}`)
    return res.data.data;
  } catch (error) {
    console.log(error)
  }
}
export async function GetByUser(userid: string,tagType:TagTypeEnum): Promise<any> {
  try {
    let res=await http.get(`Tag/User/${userid}/${tagType}`)
    return res.data.data;
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

import { defineStore, storeToRefs } from 'pinia'
import { Get, GetByTitle, GetByType, Post, GetById, GetForProject,GetForKeeps } from '@/Services/TagService'
import type { TagTypeEnum } from '@/enum/TagTypeEnum'
import type { ITag } from '@/Models/TagModel'
import { ref, type Ref } from 'vue'
import { useUserStore } from '@/stores/UserStore'

export const tagStore = defineStore('TagStore', () => {
  const { User } = storeToRefs(useUserStore())
  const Tags: Ref<ITag[]> = ref([])
  const TagsByType: Ref<ITag[]> = ref([])
  async function GetAll(): Promise<any> {
    const [response, error] = await Get()
    if(!error && response) 
    Tags.value = response.data.data
    return [response, error]
  }
  async function GetByTagId(tagId: string): Promise<any> {
    try {
      return await GetById(tagId)
    } catch (error) {
      console.log(error)
    }
  }
  async function GetByTagType(tagType: TagTypeEnum): Promise<any> {
    try {
      var res = await GetByType(tagType)
      TagsByType.value = res.data.data
      return res
    } catch (error) {
      console.log(error)
    }
  }

  async function GetByTagTitle(title: string): Promise<any> {
    try {
      return await GetByTitle(title)
    } catch (error) {
      console.log(error)
    }
  }
  async function TagForProject(): Promise<any> {
    try {
      let res = await GetForProject(User.value!.id.toString())
      TagsByType.value = res
      return res
    } catch (error) {
      console.log(error)
    }
  }
  async function TagForKeeps(projectId:string): Promise<any> {
    try {
      let res = await GetForKeeps(User.value!.id.toString(),projectId)
      TagsByType.value = res
      return res
    } catch (error) {
      console.log(error)
    }
  }
  async function Add(tag: ITag): Promise<any> {
    try {
      return await Post(tag)
    } catch (error) {
      console.log(error)
    }
  }
  return {
    GetAll,
    GetByTagId,
    GetByTagTitle,
    GetByTagType,
    Add,
    Tags,
    TagsByType,
    TagForProject,
    TagForKeeps
  }
})

import { defineStore } from 'pinia'
import { Get, GetByTitle, GetByType, Post } from '@/Services/TagService'
import type { TagTypeEnum } from '@/enum/TagTypeEnum'
import type { ITag } from '@/Models/TagModel'
import { ref, type Ref } from 'vue'
export const tagStore = defineStore('TagStore', () => {
  const Tags: Ref<ITag[]> = ref([])
  async function GetAll(): Promise<any> {
    try {
      var res=await Get()
      Tags.value=res.data.data
      return res;

    } catch (error) {
      console.log(error)
    }
  }
  async function GetByTagType(tagType: TagTypeEnum): Promise<any> {
    try {
      return await GetByType(tagType)
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

  async function Add(tag: ITag): Promise<any> {
    try {
      return await Post(tag)
    } catch (error) {
      console.log(error)
    }
  }
  return {
    GetAll,
    GetByTagTitle,
    GetByTagType,
    Add,
    Tags
  }
})

import { defineStore, storeToRefs } from 'pinia'
import { Get, GetByTitle, GetByType, Post, GetById, GetByUser } from '@/Services/TagService'
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
  async function GetTagByUser(tag: TagTypeEnum): Promise<any> {
    try {
      let res = await GetByUser(User.value!.id.toString(), tag)
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
    GetTagByUser
  }
})

import type { Ikeep } from '@/Models/KeepModel'
import { type Ref, ref } from 'vue'
import { defineStore, storeToRefs } from 'pinia'
import { Insert, Update, Delete, GetAll, GetById } from '@/Services/KeepService'
import { useUserStore } from './UserStore'
export const useKeepStore = defineStore('KeepStore', () => {
  const { User } = storeToRefs(useUserStore())
  const Keeps: Ref<Ikeep[]> = ref([])
  async function AddKeep(keep: Ikeep): Promise<any> {
    keep.createdBy = User.value?.id
    await Insert(keep)
  }
  async function GetKeepById(KeepId: string): Promise<any> {
    return await GetById(KeepId)
  }
  async function GetKeeps(projectId: string): Promise<any> {
    const keeps = await GetAll(projectId)
    Keeps.value = keeps.data.data
  }
  async function DeleteKeep(ProjectId: string): Promise<any> {
    await Delete(ProjectId)
  }
  async function Updatekeep(Keep: Ikeep): Promise<any> {
    Keep.updatedBy = User.value?.id
    await Update(Keep)
  }
  return {
    AddKeep,
    GetKeepById,
    GetKeeps,
    DeleteKeep,
    Updatekeep,
    Keeps
  }
})

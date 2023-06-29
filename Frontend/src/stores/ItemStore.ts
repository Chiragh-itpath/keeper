import { defineStore } from 'pinia'
import { Insert, Update, Delete, Get, GetAll } from '@/Services/ItemService'
import type { IItem } from '@/Models/ItemModel'
import { useUserStore } from '@/stores/UserStore'
import { type Ref, ref } from 'vue'
export const useItemStore = defineStore('ItemStore', () => {
  const { User } = useUserStore()
  const Items: Ref<IItem[]> = ref([])
  const CurrentItem = (id: string) => Items.value.find((x) => x.Id == id)
  async function AddItem(Items:IItem): Promise<void> {
    Items.createdBy=User?.id
    await Insert(Items)
  }
  async function UpdateItem(Item:IItem): Promise<void> {
    Item.updatedBy= User?.id
    await Update(Item)
  }
  async function DeleteItem(ItemId:string): Promise<void> {
    await Delete(ItemId)
  }
  async function GetAllItems(KeepId:string): Promise<void> {
    Items.value=await GetAll(KeepId)
  }
  async function GetItem(ItemId:string): Promise<IItem> {
    return await Get(ItemId)
  }
  return {
    AddItem,
    UpdateItem,
    DeleteItem,
    GetAllItems,
    GetItem,
    Items
  }
})

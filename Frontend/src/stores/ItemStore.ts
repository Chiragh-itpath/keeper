import { defineStore } from 'pinia'
import { Insert, Update, Delete, Get, GetAll } from '@/Services/ItemService'
import type { IItem } from '@/Models/ItemModel'
import { ItemType } from '@/enum/ItemType'
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
  async function UpdateItem(): Promise<void> {
    const UserId = User?.id
    const item: IItem = {
      Title: 'item 1',
      Type: ItemType.TICKET,
      Number: '1',
      KeepId: '2191c05a-7685-4b1a-13f5-08db70aa8a03',
      UpdatedBy: UserId!
    }
    await Update(item)
  }
  async function DeleteItem(ItemId:string): Promise<void> {
    await Delete(ItemId)
  }
  async function GetAllItems(KeepId:string): Promise<void> {
    Items.value=await GetAll(KeepId)
  }
  async function GetItem(ItemId:string): Promise<void> {
    await Get(ItemId)
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

import { defineStore } from 'pinia'
import { Insert, Update, Delete, Get, GetAll } from '@/Services/ItemService'
import type { IItem } from '@/Models/ItemModel'
import { ItemType } from '@/enum/ItemType'
import { useUserStore } from '@/stores/UserStore'
import { type Ref, ref } from 'vue'
export const useItemStore = defineStore('ItemStore', () => {
  const { User } = useUserStore()
  const Items: Ref<IItem[]> = ref([])
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  const CurrentItem = (id: string) => Items.value.find((x) => x.Id == id)
  async function AddItem(): Promise<void> {
    const UserId = User?.id
    const item: IItem = {
      Title: 'item 1',
      Type: ItemType.TICKET,
      Number: '1',
      KeepId: '2191c05a-7685-4b1a-13f5-08db70aa8a03',
      CreatedBy: UserId!,
      ProjectId: 'b00c6df0-381e-40b5-a8f5-08db70aa30e5'
    }
    await Insert(item)
  }
  async function UpdateItem(): Promise<void> {
    const UserId = User?.id
    const item: IItem = {
      Title: 'item 1',
      Type: ItemType.TICKET,
      Number: '1',
      KeepId: '2191c05a-7685-4b1a-13f5-08db70aa8a03',
      UpdatedBy: UserId!,
      ProjectId: 'b00c6df0-381e-40b5-a8f5-08db70aa30e5'
    }
    await Update(item)
  }
  async function DeleteItem(): Promise<void> {
    const ItemId: string = '7c0d9ee4-4a54-4df5-2493-08db718e0c75'
    await Delete(ItemId)
  }
  async function GetAllItems(): Promise<void> {
    const KeepId: string = ''
    await GetAll(KeepId)
  }
  async function GetItem(): Promise<void> {
    const ItemId: string = '7c0d9ee4-4a54-4df5-2493-08db718e0c75'
    await Get(ItemId)
  }
  return {
    AddItem,
    UpdateItem,
    DeleteItem,
    GetAllItems,
    GetItem
  }
})

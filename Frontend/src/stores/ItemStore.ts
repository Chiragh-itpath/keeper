import { ref, type Ref } from 'vue'
import { defineStore } from 'pinia'
import { ItemType } from '@/Models/enum'
import type { IItem, IAddItem, IEditItem } from '@/Models/ItemModels'
import { Insert, Update, GetAll, Get, Delete } from '@/Services/ItemService'
import { dateHelper } from '@/Services/HelperFunction'
const ItemStore = defineStore('item', () => {
    const Items: Ref<IItem[]> = ref([])
    const AllItems: Ref<IItem[]> = ref([])

    const KeepId: Ref<string> = ref('')
    const getSingalItem = (id: string): IItem | undefined => {
        const item = Items.value.find((x) => x.id == id)
        return item
    }

    const GetAllItems = async (id: string): Promise<void> => {
        KeepId.value = id
        const response = await GetAll(id)
        if (response) {
            AllItems.value = response
            fetchItems()
        }
    }

    const GetById = async (id: string): Promise<IItem | null> => {
        const response = await Get(id)
        if (response) {
            return response
        }
        return null
    }

    const AddItem = async (addItem: IAddItem): Promise<void> => {
        const formData = new FormData()
        formData.append('title', addItem.title)
        formData.append('type', addItem.type == ItemType.TICKET ? '0' : '1')
        formData.append('number', addItem.number.toString())
        formData.append('url', addItem.url ?? '')
        formData.append('description', addItem.description ?? '')
        formData.append('keepId', addItem.keepId)
        formData.append('to', addItem.to ?? '')
        formData.append('discussedBy', addItem.discussedBy ?? '')
        if (addItem.files != null) {
            for (const file of addItem.files) {
                formData.append('files', file)
            }
        }

        const response = await Insert(formData)
        if (response) {
            AllItems.value.push(response)
            fetchItems()
        }
    }
    const EditItem = async (editItem: IEditItem): Promise<void> => {
        const formData = new FormData()
        formData.append('id', editItem.id)
        formData.append('title', editItem.title)
        formData.append('type', editItem.type == ItemType.TICKET ? '0' : '1')
        formData.append('number', editItem.number.toString())
        formData.append('url', editItem.url ?? '')
        formData.append('description', editItem.description ?? '')
        formData.append('keepId', editItem.keepId)
        formData.append('to', editItem.to ?? '')
        formData.append('discussedBy', editItem.discussedBy ?? '')
        if (editItem.files != null) {
            for (const file of editItem.files) {
                formData.append('files', file)
            }
        }
        const response = await Update(formData)
        if (response) {
            const index = Items.value.findIndex((x) => x.id == editItem.id)
            AllItems.value.splice(index, 1, response)
            fetchItems()
        }
    }
    const fetchItems = () => {
        Items.value = AllItems.value
    }
    const DeleteItem = async (id: string): Promise<void> => {
        const response = await Delete(id)
        if (response) {
            const index = Items.value.findIndex((x) => x.id == id)
            if (index != -1) {
                AllItems.value.splice(index, 1)
                fetchItems()
            }
        }
    }
    const FilterByDate = (date: string) => {
        if (date == '') {
            fetchItems()
        } else {
            Items.value = AllItems.value.filter((x) => dateHelper(date) == dateHelper(x.createdOn))
        }
    }
    return {
        Items,
        KeepId,
        AddItem,
        EditItem,
        DeleteItem,
        GetAllItems,
        GetById,
        getSingalItem,
        FilterByDate
    }
})
export { ItemStore }

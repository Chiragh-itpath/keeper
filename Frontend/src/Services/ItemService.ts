import { http } from '@/GlobalConfig/ApiClient'
import type { IItem } from '@/Models/ItemModel'
async function GetAll(KeepId: string): Promise<any> {
  const response = await http.get(`/Item/Keep/${KeepId}`)
  return response.data.data
}
async function Insert(item: IItem) {
  try {
    let form = new FormData()
    form.append('title', item.title!)
    form.append('number', item.number!)
    form.append('url', item.url!)
    form.append('description', item.description!)
    form.append('type', item.type.toString())
    form.append('keepid', item.keepId!)
    form.append('createdby', item.createdBy!)
    if (item.files != undefined) {
      for (let file of item.files) {
        form.append('files', file)
      }
    }
    const response = await http.post('/Item', form)
  } catch (e) {
    console.log(e)
  }
}
async function Update(item: IItem) {
  try {
    let form = new FormData()
    form.append('id', item.id!)
    form.append('title', item.title!)
    form.append('number', item.number!)
    form.append('url', item.url!)
    form.append('description', item.description!)
    form.append('type', item.type.toString())
    form.append('keepid', item.keepId!)
    form.append('createdby', item.createdBy!)
    form.append('updatedby', item.updatedBy!)
    if (item.files != undefined) {
      for (let file of item.files) {
        form.append('files', file)
      }
    }
    const response = await http.put('/Item', form)
    return response.data.data
  } catch (e) {
    console.log(e)
  }
}
async function Delete(ItemId: string) {
  await http.delete(`/Item/${ItemId}`)
}
async function Get(ItemId: string): Promise<IItem> {
  const response = await http.get(`/Item/${ItemId}`)
  return response.data.data
}
export { GetAll, Insert, Update, Delete, Get }

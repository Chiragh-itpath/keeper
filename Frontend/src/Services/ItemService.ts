import { http } from '@/GlobalConfig/ApiClient'
import type { IItem } from '@/Models/ItemModel'
async function GetAll(KeepId: string): Promise<any> {
  const response = await http.get(`/Item/Keep/${KeepId}`)
  return response.data.data;
}
async function Insert(item: IItem) {
  try {
    console.log(item);
    
    const response = await http.post('/Item', item)
    console.log(response)
  } catch (e) {
    console.log(e)
  }
}
async function Update(item: IItem) {
  const form = new FormData()
  form.append('Title', item.Title)
  form.append('Type', item.Type)
  form.append('Number', item.Number)
  form.append('KeepId', item.KeepId)
  form.append('UpdatedBy', item.UpdatedBy!)
  form.append('ProjectId', item.ProjectId!)
  const response = await http.put('/Item', item)
  console.log(response)
}
async function Delete(ItemId: string) {
  const response = await http.delete(`/Item/${ItemId}`)
  console.log(response)
}
async function Get(ItemId: string) {
  const response = await http.get(`/Item/${ItemId}`)
  console.log(response)
}
export { GetAll, Insert, Update, Delete, Get }

import type { ItemType } from '@/enum/ItemType'

export interface IItem {
  id?: string
  title: string
  description?: string
  url?: string
  type: ItemType
  number: string
  to?: string
  discussedBy?: string
  keepId?: string
  createdBy?: string
  updatedBy?: string
  files?:undefined
  createdOn?: Date
}
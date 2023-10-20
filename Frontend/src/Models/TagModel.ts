import type { TagTypeEnum } from '@/Models/enum'

export interface ITag {
    id: string
    title: string
    type: TagTypeEnum
    userId: string
}

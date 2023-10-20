import type { TagTypeEnum } from '@/Models/enum'

export interface IMail {
    ToEmail: string[]
    Type: TagTypeEnum
}

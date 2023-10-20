import type { StatusType } from '@/Models/enum'

export interface IResponse {
    statusName: StatusType
    isSuccess: boolean
    message: string
    data: any
}

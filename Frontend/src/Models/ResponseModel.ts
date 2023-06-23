import type { StatusType } from '@/enum/StatusType'

export interface IResponse<Type = 'class'> {
  StatusName: StatusType
  IsSuccess: boolean
  Message: string
  Data: Type
}

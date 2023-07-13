import type { TagTypeEnum } from "@/enum/TagTypeEnum"

export interface IMail {
  ToEmail: string[]
  Type:TagTypeEnum
}

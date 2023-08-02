import type { IMail } from "./MailModel"

export interface IProject {
  id?: string
  title: string
  description: string
  createdOn?: Date
  createdBy?: string
  updatedOn?: Date
  updatedBy?: string
  tagTitle?: string
  mail?:IMail
  owner?:string[]
  contributers?:string[]
}

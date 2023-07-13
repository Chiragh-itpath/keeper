import type { IMail } from "./MailModel"

export interface Ikeep {
  id?: string
  title: string
  createdOn?: Date
  updateOn?: Date
  createdBy?: string
  updatedBy?: string
  projectId?: string
  tagTitle?: string
  mail?:IMail
}

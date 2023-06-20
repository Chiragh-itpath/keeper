import type { ItemType } from "@/enum/ItemType";

export interface IItem {
    Id?: string,
    Title: string,
    Description?: string,
    URL?: string,
    Type: ItemType
    Number: string,
    To?: string,
    DiscussedBy?: string,
    KeepId: string,
    CreatedBy?: string,
    UpdatedBy?: string,
    TagId?: string,
    ProjectId: string,
}
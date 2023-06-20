import type { TagTypeEnum } from "@/enum/TagTypeEnum";
import type { Guid } from "guid-typescript";

export interface ITag {
    Id?: Guid
    Title:String
    Type:TagTypeEnum
}
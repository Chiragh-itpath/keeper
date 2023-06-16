import type { Guid } from "guid-typescript";

export interface Ikeep{
    Id?:Guid;
    Title:string;
    CreatedOn?:Date;
    UpdateOn?:Date;
    CreatedBy?:Guid;
    UpdatedBy?:Guid;
    ProjectId:Guid;
}
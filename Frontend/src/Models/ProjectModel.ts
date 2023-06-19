import type { Guid } from "guid-typescript";

export interface IProject {
    Id?: Guid;
    Title: string;
    Description: string;
    TagId?: Guid;
    TagTitle: string;
    CreatedOn?: Date;
    CreatedBy?: Guid;
    UpdatedOn?: Date;
    UpdatedBy?: Guid;
}
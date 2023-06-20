import type { Guid } from "guid-typescript";

export interface IProject {
    id?: string;
    title: string;
    description: string;
    tagId?: string;
    createdOn?: Date;
    createdBy?: string;
    updatedOn?: Date;
    updatedBy?: string;
}
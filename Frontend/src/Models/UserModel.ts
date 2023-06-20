import type { Guid } from 'guid-typescript';
export interface IUser {
    Id: Guid,
    UserName: string,
    Email: string,
    Contact: string,
    Password: string
}
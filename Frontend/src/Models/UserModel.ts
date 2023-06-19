import type { Guid } from 'guid-typescript';
export interface IUser {
    id: Guid,
    UserName: string,
    Email: string,
    Contact: string,
    Password: string
}
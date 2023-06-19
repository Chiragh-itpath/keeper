import type { Guid } from 'guid-typescript';
export interface IUser {
    id: Guid,
    userName: string,
    email: string,
    contact: string,
    Password: string
}
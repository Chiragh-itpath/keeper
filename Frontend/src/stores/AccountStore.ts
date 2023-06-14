import type { IRegister } from "@/Models/RegisterModel";
import { defineStore } from 'pinia';
import { signin, signup } from "@/Services/AccountService";
import type { ILogin } from "@/Models/LoginModel";

export const useAccountStore = defineStore('AccountStore', () => {
    async function registerUser(user: IRegister): Promise<any> {
        return await signup(user)
    }
    async function loginUser(user: ILogin): Promise<any> {
        return await signin(user)
    }
    return {
        registerUser,
        loginUser
    }
})
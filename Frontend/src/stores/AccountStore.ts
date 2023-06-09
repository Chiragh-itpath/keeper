import type { IRegister } from '@/Models/RegisterModel'
import { defineStore } from 'pinia'
import { signin, signup, GenerateOTP, ChangePassword } from '@/Services/AccountService'
import type { ILogin } from '@/Models/LoginModel'

export const useAccountStore = defineStore('AccountStore', () => {
  async function registerUser(user: IRegister): Promise<any> {
    return await signup(user)
  }
  async function loginUser(user: ILogin): Promise<any> {
    return await signin(user)
  }
  async function SendOTP(email: string): Promise<any> {
    return await GenerateOTP(email)
  }
  async function ResetPassword(user: ILogin): Promise<any> {
    return await ChangePassword(user)
  }
  return {
    registerUser,
    loginUser,
    SendOTP,
    ResetPassword
  }
})

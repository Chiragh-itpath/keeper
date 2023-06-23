import type { ILogin } from '@/Models/LoginModel'
import type { IRegister } from '@/Models/RegisterModel'
import { http } from '@/GlobalConfig/ApiClient'
async function signup(user: IRegister): Promise<any> {
  try {
    const response = await http.post('/Account/Register', user)
    return response
  } catch (e) {
    return e
  }
}

async function signin(user: ILogin): Promise<any> {
  try {
    const response = await http.post('/Account/Login', user)
    return response
  } catch (e) {
    return e
  }
}
async function GenerateOTP(email: string): Promise<any> {
  try {
    const response = await http.post('/Account/GenerateOTP', {
      email: email
    })
    return response
  } catch (e) {
    return e
  }
}
async function ChangePassword(user: ILogin): Promise<any> {
  try {
    const response = await http.post('/Account/ChangePassword', user)
    return response
  } catch (e) {
    return e
  }
}
export { signup, signin, GenerateOTP, ChangePassword }

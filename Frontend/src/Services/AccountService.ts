import { http } from '@/config/ApiClient'
import type { ILogin, IPasswordReset, IRegister } from '@/Models/UserModels'
import type { IToken } from '@/Models/TokenModel'

const signup = async (user: IRegister): Promise<void> => {
    await http.post('Account/Register', user)
}

const signin = async (user: ILogin): Promise<IToken | null> => {
    const response: IToken = await http.post('Account/Login', user)
    return response
}

const getOtp = async (email: string): Promise<string | null> => {
    const response: string = await http.get(`Account/otp?email=${email}`)
    return response
}
const ResetPassword = async (passwordReset: IPasswordReset): Promise<void> => {
    await http.put(`Account/ResetPassword`, passwordReset)
}
export { signup, signin, getOtp, ResetPassword }

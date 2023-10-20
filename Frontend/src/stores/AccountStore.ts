import { ref, type Ref } from 'vue'
import { useRouter } from 'vue-router'
import { defineStore } from 'pinia'
import { RouterEnum } from '@/Models/enum'
import type { IRegister, ILogin, IPasswordReset } from '@/Models/UserModels'
import { getOtp, signin, signup, ResetPassword } from '@/Services/AccountService'
import { setToken } from '@/Services/TokenService'

const AccountStore = defineStore('AccountStore', () => {
    const router = useRouter()
    const email: Ref<string> = ref('')
    const registerUser = async (user: IRegister): Promise<void> => {
        await signup(user)
    }
    const loginUser = async (user: ILogin): Promise<void> => {
        const response = await signin(user)
        if (response) {
            setToken(response)
            router.push({ name: RouterEnum.PROJECT })
        }
    }
    const fetchOtp = async (email: string): Promise<number | undefined> => {
        const response = await getOtp(email)
        if (response) {
            return Number(response)
        }
        return undefined
    }
    const PasswordReset = async (passwordReset: IPasswordReset): Promise<void> => {
        await ResetPassword(passwordReset)
    }
    return {
        email,
        registerUser,
        loginUser,
        fetchOtp,
        PasswordReset
    }
})

export { AccountStore }

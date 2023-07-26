import type { IUser } from '@/Models/UserModel'
import { defineStore } from 'pinia'
import { GetUser,GetByEmail,GetById } from '@/Services/UserService'
import { computed, ref } from 'vue'
import { useTokenStore } from '@/stores/TokenStore'
import { useCookies } from 'vue3-cookies'
import { useRouter } from 'vue-router'
const { cookies } = useCookies()
export const useUserStore = defineStore(
  'user',
  () => {
    const isLoading=ref(false)
    const router = useRouter()
    let User = ref<IUser>()
    const { getToken } = useTokenStore()
    async function StoreUser(id: string): Promise<void> {
      User.value = await GetUser(id)
    }
    async function GetUserByEmail(email:string):Promise<void>{
      return await GetByEmail(email)
    }
    async function GetUserById(id:string):Promise<void>{
      return await GetById(id)
    }
    const isLoggedin = computed(() => User.value != undefined && getToken() != '')
    function logout() {
      User.value = undefined
      cookies.remove('token')
      router.push('/')
    }
    return {
      StoreUser,
      User,
      isLoggedin,
      logout,
      GetUserByEmail,
      GetUserById,
      isLoading
    }
  },
  {
    persist: true
  }
)
